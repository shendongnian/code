     private void button5_Click(object sender, EventArgs e)
       {
        button5.Visible = false;
        panel2.Visible = true;
        panel1.Visible = true;
        panel3.Visible = true;
        label2.Visible = true;
        button1.Visible = true;
        button2.Visible = true;
        button3.Visible = true;
        button4.Visible = true;
        Thread thread = new Thread(new ThreadStart(StartForLoop));
        thread.Start();    
        }
 
     public void StartForLoop()
        {
          while (choice != 1 || choice != 2 || choice != 3)
         {
           if (choice == 1 || choice == 2 || choice == 3)
            {
              choice = 1000;
              break;
            }
           Application.DoEvents();
         }
    
        if(choice==3)//why
        {
        }
        if(choice==1)//true
        {
        label2.Text = "asdasd";
        }
        if(choice==2)//false
        {
        }
       }
