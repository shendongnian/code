    public class Page 
    {
        public Page() 
        {
            Lines = new List<Line>();
        }
     
        public List<Line> Lines { get; private set; }
    
        public static Page WithLines(params string[] texts)
        {
            var page = new Page();
            foreach(var text in texts)
               page.Lines.Add(new Line { Text = text });
            return page;
        }
    }
