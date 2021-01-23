    private void OK_Click(object sender, eventArgs e)
    {
     DoCheck();
     DialogResult = DialogResult.OK; //this closes your form
    }
    private void DoCheck()
    {
     if(checkBox1.Checked)
     {
      //Set your value on true
      MyValues.Confirm = true;
     }
    }
