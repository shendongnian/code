    if (e.CommandName == "O1")
    {
      Button O1Button = (Button)row.FindControl("O1Button");
      //Change the background-color:
      O1Button.Style.Add("background-color", "yellow");
      //Change the class
      O1Button.CssClass = "class-name";
    }
    else if (e.CommandName == "O2")
    {
        //chnaging the css of O2 button JUST IN THIS ROW
        Button O2Button = (Button)row.FindControl("O2Button");
      //Change the background-color:
      O2Button.Style.Add("background-color", "yellow");
      //Change the class
      O2Button.CssClass = "class-name";
    }
    else if (e.CommandName == "O3")
    {
        //chnaging the css of O3 button JUST IN THIS ROW
        Button O3Button = (Button)row.FindControl("O3Button ");
      //Change the background-color:
      O3Button.Style.Add("background-color", "yellow");
      //Change the class
      O3Button.CssClass = "class-name";
    }
    else if (e.CommandName == "O4")
    {
        //chnaging the css of O4 button JUST IN THIS ROW
        Button O4Button= (Button)row.FindControl("O4Button");
      //Change the background-color:
      O4Button.Style.Add("background-color", "yellow");
      //Change the class
      O4Button.CssClass = "class-name";
    }     
