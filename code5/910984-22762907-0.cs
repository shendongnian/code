    void Form1_DragDrop(object sender, DragEventArgs e)
    {
       foreach (String s e.Data.GetData(DataFormats.FileDrop))
       {
          Button button = new Button(); 
          button.Click += new EventHandler(this.button_Click);
          flowLayoutPanel1.Controls.Add(button);
          path_app = String.Format("{0}", s);
    
          // Add to Tag any data you want to pin to the button
          button.Tag = path_app;
       }
    }
    
    private void button_Click(object sender, System.EventArgs e)
    {
       // Obtain via Tag
       String path_app = ((sender as Button).Tag as String); 
    
       myProcess.StartInfo.FileName = path_app;
       myProcess.Start();
    } 
