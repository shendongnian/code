    public class MyViewModel
    {
        public ITextBuffer Description { get; set; }
    
        public MyViewModel()
        {
            Description= new MyTextBuffer();
                
            Description.Append("Just testing out.");
        }
    }
