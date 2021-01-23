        public partial class Form1 : Form
        {
            HashSet<string> books = new HashSet<string>();
    
            // (...)
        }
    I used generic `HashSet<string>` here, because it's the right one to use in your case.
