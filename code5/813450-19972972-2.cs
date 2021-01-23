    public class Field
    {
        private dynamic Value { get; set; }
        public void Serialize(StringWriter sw)
        {
            try
            {
                Value.Serialize(sw);
            }
            catch (RuntimeBinderException ex)
            {
                throw new InvalidOperationException(string.Format("Instance of type {0} does not implement a Serialize method", Value.GetType()), ex);
            }
        }
    }
