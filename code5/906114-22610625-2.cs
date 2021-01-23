    var myButton = Controls.Find("buttonName", true).FirstOrDefault(); //Gets control by name
    if(myButton != null)
    {
        if (myButton.GetType() == typeof(Button)) //Check if selected control is of type Button
        {
           //Edit button here...
        }
        else
        {
           //Control isn't a button
        }
    }
    else
    {
        //Control not found.
    }
