    public class ComWrapper : DynamicObject {
        Object _instance;
        Type _type;
        // Create + save type/instance information in constructor
        // You seem to do this differently, so you'd want to change this...
        public ComWrapper(Guid guid) {
            _type = Type.GetTypeFromCLSID(guid, true);
            _instance =  Activator.CreateInstance(_type, true);            
        }
        // Invoke requested method, passing in args and assigning return value
        // to result
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, 
                                             out object result) {
            result = _type.InvokeMember(binder.Name, 
                                        System.Reflection.BindingFlags.InvokeMethod, null,
                              _instance, args);
            return true;  // Return true to indicate it's been handled
        }
    }
