    bool run = false;
    string message = "This API is not original";
    private void Spam()
      {
           while (run == true)
          {
            MessageBox.Show(message); 
          } 
         } 
       }
    
     private void button1_Click(object sender, EventArgs e)
            {
              message = "Hellooo";
              flag = true;
              Spam();
            }
     private void button2_Click(object sender, EventArgs e)
            {
              flag = false;
            }
