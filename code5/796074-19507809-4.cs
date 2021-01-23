    public partial class Form1 : Form
    {
        public static string searchT; // Static searchT string as per your requirement
        public Form1()
        {
            InitializeComponent();
        }
       public void searchText() // search function
       {
        if (searchT != null)
        {
            if (textBox1.TextLength > 0)
            {
                if (textBox1.Text.Contains(searchT))
                {
                    textBox1.SelectionStart = textBox1.Text.IndexOf(searchT);
                    textBox1.SelectionLength = searchT.Length;
                }
            }
        }
      }    
    }
