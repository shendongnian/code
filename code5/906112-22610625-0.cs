    Control myButton = Controls.Find("buttonName"); //Gets control by name
    if (myButton.GetType() == typeof(Button)) //Check if selected control is of type Button
    {
       //Edit button here...
    }
    else
    {
       //Control isn't a button
    }
