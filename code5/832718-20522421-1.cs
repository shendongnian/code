    public class MyModel : IEnumerable<KeyValuePair<string, object>>
    {
        public string Level1_TypeName { get; set; }
        public string Level1_AttrType { get; set; }
        public string Level1_AttrValue { get; set; }
        public string Level2_TypeName { get; set; }
        public string Level2_AttrType { get; set; }
        public string Level2_AttrValue { get; set; }
        public string Level3_TypeName { get; set; }
        public string Level3_AttrType { get; set; }
        public string Level3_AttrValue { get; set; }
        public string Level4_TypeName { get; set; }
        public string Level4_AttrType { get; set; }
        public string Level4_AttrValue { get; set; }
        public string Level5_TypeName { get; set; }
        public string Level5_AttrType { get; set; }
        public string Level5_AttrValue { get; set; }
        public string Level6_TypeName { get; set; }
    
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToDictionary(p => p.Name, p => p.GetGetMethod().Invoke(this, null)).GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
