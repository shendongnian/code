    class Program
    {
        static void Main(string[] args)
        {
            var th = new This();
            th.OnSaved(); //creator receives a saved event
        }
    }
    public class This
    {
        public event EventHandler Saved;
        public virtual void OnSaved()//made public in that example
        {
            if (Saved != null)
            {
                Saved(this, EventArgs.Empty);
            }
        }
        public This()
        {
            var rxs = new List<int> { 1, 2, 3 };
            foreach (var rx in rxs)
            {
                var svm = new StringByColumnViewModel();
                this.Saved += svm.OnSaved;
            }
        }
    }
    public class StringByColumnViewModel
    {
        public EventHandler OnSaved;
        public StringByColumnViewModel()
        {
            this.OnSaved = (s, e) => { Console.WriteLine("Here I am"); };
        }
    }
