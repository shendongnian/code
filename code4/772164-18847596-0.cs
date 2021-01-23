    public class MyClass {
        private string _keywords;
    
        public virtual IEnumerable<string> Keywords {
            get { return _keywords.Split(','); }
            set { _keywords = string.Join(value, ","); }
        }
    }
