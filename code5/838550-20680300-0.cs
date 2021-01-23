    public class Child
    {
        public void logChild(params object[] parameters)
        {
            foreach (object value in parameters)
            {
                Type type = typeof(object);
                if (!object.ReferenceEquals(value, null))
                    type = value.GetType();
                // now do something with (type, value)
            }
        }
    }
