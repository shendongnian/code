    public class MyClass : IFormattable
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "X": return x.ToString();
                case "Y": return y.ToString();
                // ...
            }
            
            return this.ToString();        
        }
    }
