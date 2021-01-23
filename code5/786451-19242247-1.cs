    public FormB : UserControl
    {
        FormA s = null;
        string txtInput = String.Empty;
    
        public FormB (FormA form1handle)
        {
           InitializeComponent();
            s = form1handle;
        }
    
        public string getFormBValue {
            get { return txtInput; }
        }
    
     private void Dial1_Click(object sender, EventArgs e)
        {
            //txtInput = Dial1.Text;
            s.getValue = Dial1.Text;
            MessageBox.Show(s.getValue.ToString());           
        }
      }
