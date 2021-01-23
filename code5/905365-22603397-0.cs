    protected void SetActiveView_Click(object sender, EventArgs e)
    {   
       Button activeButton= (Button) sender;
          switch (activeButton.ID)
	{
          Case "LinkButton2" :
	usradnmultiview.ActiveViewIndex = 0;
            break;
          Case "LinkButon3" :
         usradnmultiview.ActiveViewIndex = 1;
            break;
            default:
            return "Invalid";
                    
          }
     }
