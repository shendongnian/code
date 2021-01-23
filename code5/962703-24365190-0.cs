    public class PyroProxy : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.WriteLine(binder.Name + " was invoked");
            return true;
        }
    }
    
    dynamic proxy = new PyroProxy();
    proxy.SomeMethod(); //prints "SomeMethod was invoked"
