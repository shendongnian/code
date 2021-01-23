    public class MyDynamicObject<T> : DynamicObject {
        private T referenceObject;
        public MyDynamicObject<T>() {
            this.referenceObject = new T();
        }
        public override bool TrySetMember(SetMemberBinder binder, Object value) {
            var propertyName = // get from binder parameter
            typeof(T).SetValue(referenceObject, value);
        }
        public T Compile() {
            return referenceObject;
        }
    }
