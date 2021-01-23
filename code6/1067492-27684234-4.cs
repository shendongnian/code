    class ToStringExpandoObject : DynamicObject
    {
        public IDictionary<string, object> Members { get; private set; }
        public ToStringExpandoObject()
        {
            this.Members = new Dictionary<string, object>();
        }
        public override bool TryDeleteMember(DeleteMemberBinder binder)
        {
            return this.Members.Remove(binder.Name);
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            return this.Members.TryGetValue(binder.Name, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            this.Members[binder.Name] = value;
            return true;
        }
        public override string ToString()
        {
            //see if we defined a ToString member
            //if not, use the base implementation
            object methodObj;
            this.Members.TryGetValue("ToString", out methodObj);
            ToStringFunc method = methodObj as ToStringFunc;
            if (method == null)
                return base.ToString();
            return method();
        }
    }
