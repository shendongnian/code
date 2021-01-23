     public class Derived : Base
    {
        public Derived(string message)
        {
            Type type = typeof(Ancestor);
            Ancestor a = (Ancestor)this;
            type.GetProperty("Property").SetMethod.Invoke(a, new[] { message });
        }
    }
