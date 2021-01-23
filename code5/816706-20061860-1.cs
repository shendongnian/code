      private void button1_Click(object sender, EventArgs e)
      {
           // Let just say that the data is sent back once you click a button
            FormBData = "Hello World!"; 
            Close();
       }
       public String FormBData { get; set; }
