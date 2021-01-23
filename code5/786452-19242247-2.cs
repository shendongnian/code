    public FormB : UserControl
    {
        FormA s = null;
        string txtInput = String.Empty;
    
        public FormB (FormA form1handle)
        {
           InitializeComponent();
            s = form1handle;
        }
        public FormB()
        {
        }
        public FormA Parent 
        { 
            get 
            { 
                if(s == null)
                   s = (FormA)ParentForm; 
                 return s; 
             } 
         }
    
        public string getFormBValue {
            get { return txtInput; }
        }
    
     private void Dial1_Click(object sender, EventArgs e)
        {
            //txtInput = Dial1.Text;
            Parent.getValue = Dial1.Text;
            MessageBox.Show(Parent.getValue.ToString());           
        }
      }
