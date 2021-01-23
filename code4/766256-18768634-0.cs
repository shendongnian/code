    public class AnyInvokeObject:DynamicObject{
        Func<object[],object> _func;
        public AnyInvokeObject(Func<object[],object> func){
           _func = func;
        }
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result){
	       result = _func(args);
	       return true;
        }
    }
