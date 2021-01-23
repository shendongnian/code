    var items = new List<FlowSettings>();
    
    for(var i = 0; i < length; i++)
    {
        var flowSettings = new FlowSettings
        {
            IsVisible = ParseBool(formCollection.GetValues("IsVisible")[i]),
            Editable = ParseBool(formCollection.GetValues("Editable")[i]),
            Revisable = ParseBool(formCollection.GetValues("Revisable")[i]),
            TblId = ParseInt(formCollection.GetValues("tblId")[i]),
        };
        
        items.Add(flowSettings);
    }
