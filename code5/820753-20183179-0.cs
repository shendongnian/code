        public partial class Form1 : Form
        {
            HashTable<string> books = new HashTable<string>();
    
            // (...)
        }
    I used generic `HashTable<string>` here, because it's the right one to use in your case.
