    public class ClassA
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public override string ToString()
        {
            string ret = string.Empty;
            foreach (PropertyInfo pi in base.GetType().GetProperties())
            {
                ret += string.Format("{0}: {1}\r\n", pi.Name, pi.GetValue(this, null).ToString());
            }
            return ret;
        }
    }
