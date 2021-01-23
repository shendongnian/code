    class MyClass
    {
        public int IntValue { get; set; }
        public string SomeMethod(int i)
        {
            return i.ToString();
        }
        public string SomeOtherMethod()
        {
            return "Hello";
        }
    }
    class Wrapper : DynamicObject
    {
        private object wrappedObject;
        public Wrapper(object wrappedObject)
        {
            this.wrappedObject = wrappedObject;
        }
        private void Wrap(object someObject)
        {
            wrappedObject = someObject;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo prop = wrappedObject.GetType()
                .GetProperty(binder.Name, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
            {
                result = null;
                return false;
            }
            result = prop.GetValue(wrappedObject, null);
            return true;
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            PropertyInfo prop = wrappedObject.GetType()
                .GetProperty(binder.Name, BindingFlags.Instance | BindingFlags.Public);
            if (prop == null)
            {
                return false;
            }
            prop.SetValue(wrappedObject, value);
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            MethodInfo method = wrappedObject.GetType()
                .GetMethod(binder.Name, BindingFlags.Instance | BindingFlags.Public);
            if (method == null)
            {
                result = null;
                return false;
            }
            result = method.Invoke(wrappedObject, args);
            return true;
        }
    }
    MyClass a = new MyClass();
    dynamic d = new Wrapper(a);
    d.IntValue = 5;
    string s = d.SomeOtherMethod();
    Console.WriteLine(a.IntValue);
