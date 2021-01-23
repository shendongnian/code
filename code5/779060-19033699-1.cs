    public Form1()
    {
        InitializeComponent();
    
        DynamicTypeDescriptor dt = new DynamicTypeDescriptor(typeof(MyBeautifulClass));
    
        // initialize the class the way you want
        MyBeautifulClass c = new MyBeautifulClass();
        c.MyProperty = "hello world";
        // we need to replace a property by another version, so let's remove the existing one
        dt.RemoveProperty("MyProperty");
        // create a new similar property with a new editor and the current value
        dt.AddProperty(
            typeof(string),            // type
            "MyProperty",              // name
            c.MyProperty,              // value
            "My Property",             // display name 
            "My Property Description", // description
            "My Category",             // category
            false,                     // has default value?
            null,                      // default value
            false,                     // readonly?
            typeof(MyEditor));         // editor 
        // create a wrapped object from the original one.
        // unchanged properties will keep their current value
        var newObject = dt.FromComponent(c);
        // hook on value change
        newObject.PropertyChanged += (sender, e) =>
        {
            // update the original object
            // note: the code could be made more generic
            c.MyProperty = newObject.GetPropertyValue<string>(e.PropertyName, null);
        };
        propertyGrid1.SelectedObject = newObject;
    }
    public class MyBeautifulClass
    {
        public string MyProperty { get; set; }
    }
    // this stupid sample editor puts a current string in upper case... :-)
    public class MyEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            return value == null ? value : value.ToString().ToUpper();
        }
    }
