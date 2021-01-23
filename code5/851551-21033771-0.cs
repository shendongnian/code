    public Form1(){
                InitializeComponent();
                if (listBox1.Items.Count < 6)
                {
        
                    listBox1.Height = listBox1.Items.Count*12+9;
                }
                else
                {
                    listBox1.Height = 69;
                }
                
            }
