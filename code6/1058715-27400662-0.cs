    public class TextContext
    {
        public int ID { get; set; }
        public int Title { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        List<Keyword> Keywords;    
        public string SomeMethod()
        {
            return string.Format("{0}\r\n{1}", Title, Text);
        }
    }
    
    public class Article : TextContext
    {
       ...
    }
