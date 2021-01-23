    foreach (Control c in Page.Controls)
    {
       if (c is CheckBox)
       {
          CheckBox myCheckBox = (CheckBox)c;
          myCheckBox.Enabled = false;
       }
    }
