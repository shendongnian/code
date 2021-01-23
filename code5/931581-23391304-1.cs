    Form1 _parentform;
    public Form2(Form1 parent)
            {
                _parentform=parent;
                InitializeComponent();
            }
    
            
        
    private void CloseButton_Click(object sender, EventArgs e)
            {
                _parentform.Show();
                this.Close();
            }
