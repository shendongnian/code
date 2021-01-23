    Protected override void OnClosing()
    {
     DoCheck();
    }
    private void OK_Click(object sender, eventArgs e)
    {
     DoCheck();
    }
    private void DoCheck()
    {
     if(checkBox1.Checked)
     {
      //Set your value on true
     }
    }
