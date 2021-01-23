    public class Class
    {
        private string p1;
        private int p2;
        private decimal p3;
    
        public void SetPi<T>(string name, T value)
        {
            var field = this.GetType().GetField(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            if (field == null)
                throw new ArgumentException("Field not found in Class.");
    
            field.SetValue(this, value);
        }
    }
