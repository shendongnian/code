        public Form1()
        {
            InitializeComponent();
            Initialize(typeof(ClassA), typeof(ClassB));
        }
        public class BaseClass { }
        public class ClassA : BaseClass { }
        public class ClassB : BaseClass { }
        public BaseClass[] Initialize(params Type[] lst)
        {
            // if we already know the item count, why not set the capacity of the list.
            List<BaseClass> instances = new List<BaseClass>(lst.Length);
            foreach (Type type in lst)
                if (type.IsSubclassOf(typeof(BaseClass)))
                    instances.Add((BaseClass)Activator.CreateInstance(type));
            return instances.ToArray();
        }
