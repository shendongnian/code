    class B
    {
        object _object;
        public void Wrap(object someObject)
        {
            _object = someObject;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = _object.GetType().InvokeMember(
                    binder.Name,
                    BindingFlags.InvokeMethod |
                    BindingFlags.Public |
                    BindingFlags.Instance,
                    null, _object, args);
                    return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }
    }
