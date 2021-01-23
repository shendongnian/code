    public partial class Form1 : Form
    {
        List<Foo> foo = new List<Foo>();
        public List<Foo> Foo
        {
            get { return foo; }
            set { foo = value; }
        }
        public Form1()
        {
            InitializeComponent();
            foo.Add(new WindowsFormsApplication1Foo());
            foo.Add(new WindowsFormsApplication1.Foo());
            BindingSource source = new BindingSource();
            source.DataSource = Foo;
            dataGridView1.DataSourceChanged += new EventHandler(dataGridView1_DataSourceChanged);
            dataGridView1.DataSource = Foo.ToArray();
        }
        bool sourceChange = true;
        void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (sender is DataGridView)
            {
                DataGridView dgv = (DataGridView)sender;
                if (sourceChange)
                {
                    sourceChange = false;
                    object source = dgv.DataSource;
                    Type sourceType = source.GetType();
                    if (sourceType.IsArray)
                    {
                        Array arr = (Array)source;
                        if (arr.Length > 0)
                        {
                            Type elementType = sourceType.GetElementType();
                            Type myType = CreateCustomType(elementType);
                            List<object> list = new List<object>();
                           
                            IEnumerator enumerator = arr.GetEnumerator();
                            while (enumerator.MoveNext())
                            {
                                object myNewTypeInstance=null;
                                CopyData(enumerator.Current, myType,ref myNewTypeInstance);
                                list.Add(myNewTypeInstance);
                            }
                            dgv.DataSource = list;
                        }
                    }
                }
            }
        }
        private void CopyData(object oldObj, Type newType,ref object newObj)
        {
            if(newObj==null)
                newObj = Activator.CreateInstance(newType);
            Type oldType = oldObj.GetType();
            foreach (var item in oldType.GetProperties())
            {
                string name = item.Name;
                object value = oldType.GetProperty(item.Name).GetValue(oldObj,null);
                if (item.PropertyType.Namespace != "System")
                {
                    CopyData(value, newType,ref newObj);
                }
                else
                {
                    newType.GetProperty(name).SetValue(newObj, value, null);
                }
            }
        }
        private Type CreateCustomType(Type t)
        {
            AppDomain myDomain = Thread.GetDomain();
            AssemblyName myAsmName = new AssemblyName() { Name = "MyDynamicAssembly" };
            AssemblyBuilder myAsmBuilder = myDomain.DefineDynamicAssembly(myAsmName, AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder myModBuilder = myAsmBuilder.DefineDynamicModule(myAsmName.Name, myAsmName.Name + ".dll");
            TypeBuilder myTypeBuilder = myModBuilder.DefineType("MyDynamicClass", TypeAttributes.Public);
            DefineProperties(myTypeBuilder, t);
            return myTypeBuilder.CreateType();
        }
        private void DefineProperties(TypeBuilder tBuilder, Type t)
        {
            MethodAttributes getSetAttr = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
            foreach (var item in t.GetProperties())
            {
                Type _t = item.PropertyType;
                if (_t.Namespace != "System")
                {
                    DefineProperties(tBuilder, _t);
                }
                else
                {
                    FieldBuilder customerNameBldr = tBuilder.DefineField("_" + item.Name, item.PropertyType, FieldAttributes.Private);
                    PropertyBuilder custNamePropBldr = tBuilder.DefineProperty(item.Name, System.Reflection.PropertyAttributes.HasDefault, item.PropertyType, null);
                    MethodBuilder custNameGetPropMthdBldr = tBuilder.DefineMethod("get_" + item.Name, getSetAttr, item.PropertyType, Type.EmptyTypes);
                    ILGenerator custNameGetIL = custNameGetPropMthdBldr.GetILGenerator();
                    custNameGetIL.Emit(OpCodes.Ldarg_0);
                    custNameGetIL.Emit(OpCodes.Ldfld, customerNameBldr);
                    custNameGetIL.Emit(OpCodes.Ret);
                    MethodBuilder custNameSetPropMthdBldr = tBuilder.DefineMethod("set_" + item.Name, getSetAttr,null, new Type[] { item.PropertyType });
                    ILGenerator custNameSetIL = custNameSetPropMthdBldr.GetILGenerator();
                    custNameSetIL.Emit(OpCodes.Ldarg_0);
                    custNameSetIL.Emit(OpCodes.Ldarg_1);
                    custNameSetIL.Emit(OpCodes.Stfld, customerNameBldr);
                    custNameSetIL.Emit(OpCodes.Ret);
                    custNamePropBldr.SetGetMethod(custNameGetPropMthdBldr);
                    custNamePropBldr.SetSetMethod(custNameSetPropMthdBldr);
                }
                
            }
        }
    }
