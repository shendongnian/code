    if (e.CommandName == "O1")
    {
        //chnaging the css of O1 button JUST IN THIS ROW
        Button O1Button = (Button)row.FindControl("O1Button");
        //Change the background-color:
        O1Button.Style.Add("background-color", "yellow");
        //Change the class
        O1Button.CssClass = "class-name";
    }
