    public class StringByColumnViewModel
    {
        public event EventHandler OnSaved;
        public StringByColumnViewModel()
        {
            this.OnSaved = (s, e) => { Console.WriteLine("Here I am"); };
        }
        public void RaiseSave(object sender, EventArgs e)
        {
            var handler = OnSaved;
            if (handler!= null)
            {
                handler(this, new EventArgs());
            }
        }
    }
