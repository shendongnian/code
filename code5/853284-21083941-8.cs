            public Rough()
            {
                InitializeComponent();
            }
            
            private void Rough_Load(object sender, EventArgs e)
            {
     
            }
            static int i = 0;
            private void button1_Click(object sender, EventArgs e)
            {
                int j = 0;
               for(;j< 3 ; i++,j++)
               {
                   TextBox txt = new TextBox();
                   txt.Size = new Size(35, 20);
                   txt.Name = i.ToString();
                   flowLayoutPanel1.Controls.Add(txt);
                }   
            }
