     publc class MyForm: Form
     {
         TextBox myBox = null;  // class member
           
         void MainFormLoad(object sender, EventArgs e)
         {
             this.Width=600;
             this.Height=400;
             this.FormBorderStyle= FormBorderStyle.FixedDialog;
             TextBox t=new TextBox();
             myBox = t; // keep it for future reference
             
             // rest of your code
       }
       void Myb_Clicked(object sender, EventArgs e) {
              if (myBox !=null)
              {
                    myBox.Text= "Clicked!";
              }
              MessageBox.Show();
        }
    }
