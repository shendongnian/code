    private void textBox1_Validating(object sender, 
 				System.ComponentModel.CancelEventArgs e)
    {
       string errorMsg;
       bool valid = /*do some validation*/;
       if(!valid)
      {
         // to cancel validating
         e.Cancel = true;
      }
    }
