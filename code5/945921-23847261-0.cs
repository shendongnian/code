    @for (int i = 0; i < Model.Items.Count; i++)
    {
        string SelectedEvent = "event selected";    
        if (i > 1)
        {
             SelectedEvent = "event"; 
        }
        // here you can use the SelectedEventVariable
        // its value will be "event selected" on the first and second
        // iterations and "event" on subsequent 
    }
