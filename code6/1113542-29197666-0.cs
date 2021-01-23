    public class SomeClasss
    {
        public string Name { get; set; }
    
        bool _prop;
        public bool MyProp
        {
            get { return _prop; }
            set
            {
                _prop = value;
                //OnPropertyChanged(thismember);
                MethodBase method = System.Reflection.MethodBase.GetCurrentMethod();
                string methodName = method.Name;
                string className = method.ReflectedType.Name;
                Name = className + "." + methodName;
            }
        }        
    }
