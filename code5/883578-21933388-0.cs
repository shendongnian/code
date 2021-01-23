    var list = new List<string>();
    if (Details.IsNeat)
        list.Add("Neat");
    if (Details.IsDressed)
        list.Add("Dressed");
                            
    if (Details.IsDisheveled)
        list.Add("Disheveled");
                            
    if (Details.IsInappropriatelyDressed)
        list.Add("Inappropriately Dressed");
                            
    if (Details.IsAppearanceOther)
        list.Add("Other");
    var result = string.Join(", ", list);
