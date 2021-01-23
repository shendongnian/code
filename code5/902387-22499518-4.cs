    protected void btnSubmitForm_Click(object sender, EventArgs e)
    {
       if(txtSome.Text.Length==0)
       {
          label.Text = "your message for Required feild!";
       }
       else if(txt2.Text.Length==0)
       {
          label.Text = "your message for Required feild!";
       }
       else
       {
        //write code here to insert values in database. this block of code will be executed when your all text boxes will have some code. 
       }
    }
