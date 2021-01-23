    class Foo : DynamicObject {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        public Dictionary<string, object> Properties {
            get { return _properties; }
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            if (!_properties.TryGetValue(binder.Name, out result)) {
                result = new object();
                _properties.Add(binder.Name, result);
            }
            return true;
        }
    }
