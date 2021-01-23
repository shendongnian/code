    StringBuilder Sb_Appearance = new StringBuilder();
    if (Details.IsNeat == true) 
        Sb_Appearance.Append("Neat,");
    if (Details.IsDressed == true) 
        Sb_Appearance.Append("Dressed,");
    if (Details.IsDisheveled == true) 
        Sb_Appearance.Append("Disheveled,");
    if (Details.IsInappropriatelyDressed == true) 
        Sb_Appearance.Append("Inappropriately Dressed,");
    if (Details.IsAppearanceOther == true) 
        Sb_Appearance.Append("Other");
    if(Sb_Appearance[Sb_Appearance.Length - 1] == ',')
        Sb_Appearance.Remove(Sb_Appearance.Length - 1, 1);
