    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Base12
    {
        static IList<char> values = new List<char>{ '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'X', 'E' };
        public string Value { get; set; }
        public Base12(string value)
        {
            this.Value = value;
        }
        public static Base12 operator +(Base12 x, Base12 y)
        {
            var xparts = x.Value.ToArray();
            var yparts = y.Value.ToArray();
            int remember = 0;
            string result = string.Empty;
            for (int i = 0; i < Math.Max(yparts.Length, xparts.Length) ;i++)
            {
                int index = remember;
                if (i < xparts.Length)
                {
                    index += values.IndexOf(xparts[xparts.Length - i - 1]);
                }
                if (i < yparts.Length)
                {
                    index += values.IndexOf(yparts[yparts.Length - i - 1]);
                }
                if (index > 11)
                {
                    index -= 12;
                    remember = 1;
                }
                else
                {
                    remember = 0;
                }
                result = values[index] + result;
            }
            if (remember > 0)
            {
                result = values[remember] + result;
            }
            return new Base12(result);
        }
        public static implicit operator Base12(string x)
        {
            return new Base12(x);
        }
        public override string ToString()
        {
            return this.Value;
        }
    }
