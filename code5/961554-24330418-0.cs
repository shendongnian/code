    DoYourThing()
    {
        foreach(var chb in comboboxs)
        {
             if (param.Component.Attributes[0].Value == 1)    
                chb.IsChecked = true;             
        }
        childGrid.Loaded -= DoYourThing;
    }
 
     
