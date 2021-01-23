    foreach (Control control in PlaceHolder1.Controls)
    {
         if (control.ID == "TakeIDFromControlListsID")
         {
              Controls.Remove(control);
         }
    }
