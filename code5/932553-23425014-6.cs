     public Form2(string sConnectionString, ListBox.ObjectCollection objectCollection)
        {
            InitializeComponent();           
           
            this.listBox1.DataSource =  objectCollection;
            
            //use sConnectionString here
        }
