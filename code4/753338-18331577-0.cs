    public bool ShowFormParameter(IWin32Window parent)
    {
       // This creates (and automatically disposes of) a new instance of your dialog.
       // NOTE: ParameterDialog should be the name of your form class.
       using (ParameterDialog dlg = new ParameterDialog())
       {
           // Call the ShowDialog member function to display the dialog.
           if (dlg.ShowDialog(parent) == DialogResult.OK)
           {
               // If the user clicked OK when closing the dialog, we want to
               // save its settings and update the display.
               //
               // You need to write code here to save the settings.
               // It appears the caller (menuItem7_Click) is updating the display.
               ... 
               return true;               
           }
       }
       return false;  // the user canceled the dialog, so don't save anything
    }
