    protected void radCPUType_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Setup the ImageUrl.
       Image6.ImageUrl = "~/Images/MyDefault.jpg";
       
       // Setup the if-else structure to assign images w/ the selections.
       if (radCPUType.SelectedValue == "A selected option value")
       {
          Image6.ImageUrl = "~/Images/Associated Image.jpg";
       }
       else if (radCPUType.Selectedvalue == "Another selected option value")
       {
          Image6.ImageUrl = "~/Images/Another Associated Image.jpg")
       }
       else
       {
          Image6.ImageUrl = "~/Images/The Default Image.jpg";
       }
    }
