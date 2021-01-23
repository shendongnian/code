    //From form1 pass only your listbox items.
        private void button10_Click(object sender, EventArgs e)
            {
        
                var form2 = new Form2(listBox1.Items);
                form2.Show();
                this.Hide();
            }
    
     
    //In your form2 you can use AddRange()
        public Racun(ListBox.ObjectCollection Items)
            {
                InitializeComponent();		
        		
                listBox1.Items.AddRange(items);
              
            } 
