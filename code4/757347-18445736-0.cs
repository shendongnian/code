    public class ViewModel
    {
        public ViewModel()
        {
             this.md = new Mydata();
             this.cp = new Company();
        }
        public Mydata md { get; set; }
        public Company cp { get; set; }
    }
