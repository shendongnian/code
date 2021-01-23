    SLMessageBox messBox;
    messBox = new SLMessageBox("Message", "Yes, No and Cancel Buttons Message Box...!", SLMessageBox.MessageBoxButtons.YesNoCancel, , SLMessageBox.MessageBoxIcon.Information);
    messBox.Show();
    messBox.OnMessageBoxClosed += messBox_OnDeleteMessageBoxClosed;
    private void messBox_OnDeleteMessageBoxClosed(MessageBoxResult result)
    {
       if(result==MessageBoxResult.Yes)
       {
         //....
       }
       else if(result==MessageBoxResult.No)
       {
         //....
       }
       else
       {
         //...
       }
    }
    
