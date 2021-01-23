    Int32 Record;  
    if(txtName.Text=="")
    {
      if(txtCode.Text!="")
      {
      Record = DisplayCode(txtCode.Text);
      lblResult.Text = Record + " records found";
      txtCode.Text = "";
      }
      else
      {
       lblResult.Text = "enter name/code to search ";
      }
    }
    else
    {         
      Record = DisplayName(txtName.Text);      
      lblResult.Text = Record + " records found";
      txtName.Text = "";
    }
