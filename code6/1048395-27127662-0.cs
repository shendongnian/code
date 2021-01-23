    public sealed class Patchable<T> : DynamicObject where T : class {
        private readonly IDictionary<PropertyInfo, object> changedProperties = new Dictionary<PropertyInfo, object>();
        public override bool TrySetMember(SetMemberBinder binder, object value) {
            var pro = typeof (T).GetProperty(binder.Name);
            if (pro != null)
                changedProperties.Add(pro, value);
            return base.TrySetMember(binder, value);
        }
        public void Patch(T delta) {
            foreach (var t in changedProperties)
                t.Key.SetValue(
                    delta,
                    t.Key.PropertyType.IsEnum ? Enum.Parse(t.Key.PropertyType, t.Value.ToString()) : Convert.ChangeType(t.Value, t.Key.PropertyType));
        }
    }
