    class DynamicWrapper : DynamicObject
    {
        private readonly object _contents;
        public DynamicWrapper(object obj)
        {
            _contents = obj;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            if (binder.Name == "ExtraFunctionality")
            {
                // extra functionality
                return true;
            }
            var method = _contents.GetType()
                                 .GetRuntimeMethods()
                                 .FirstOrDefault(m => m.Name == binder.Name);
            if (method == null)
            {
                result = null;
                return false;
            }
            method.Invoke(_contents, args);
        }
    }
