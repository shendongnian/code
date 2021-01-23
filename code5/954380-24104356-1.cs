     using(MainForm form = new MainForm())
     {
          DialogResult dr = form.ShowDialog();
          if(dr == DialogResult.OK)
          {
             // User presses OK button, 
             // read the public property UserName and 
             // appply your logic here.
             string userName = form.UserName;
          }
          else if(dr == DialogResult.Cancel)
          {
             // User presses Cancel button
             MessageBox.Show("Login aborted");
          }
    }
