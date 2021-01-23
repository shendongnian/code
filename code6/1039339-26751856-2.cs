    List<string> txtOppsNames = new List<string>(); 
    for (int i = 1; i < numOpps; i++) 
    {
        txtOppsNames.Add("txtOpp" + i);
    }
    foreach (var txtName in txtOppsNames) 
    {
       var control = this.Controls.Find(txtName, true).FirstOrDefault();
       if(control != null && control is TextBox)
       {
          TextBox textBox = control as TextBox;
          if(textBox.Text != string.Empty)
          {
              //logic
          }
       } 
     }
