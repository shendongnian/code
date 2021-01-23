    public class MyItem
    {
        private string _value;
        public MyItem(string content)
        {
            _value = content;
        }
        public void Append(string other)
        {
            _value += other;
        }
        public void ReplaceWith(Func<string, string> replacer)
        {
            _value = replacer(_value); 
        }
    }
