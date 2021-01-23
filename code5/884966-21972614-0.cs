     namespace PreviewForm
      {
        private  string _filename = string.Empty;
         public partial class Preview : Form
        {
            int ind1 = 1;
    
            public Preview(string filename)
        {
            InitializeComponent();
              _filename = filename;  
        }
