    StringBuilder Sb_Appearance = new StringBuilder();
    if (Details.IsNeat) Sb_Appearance.Append(",Neat");
    if (Details.IsDressed) Sb_Appearance.Append(",Dressed");
    if (Details.IsDisheveled) Sb_Appearance.Append(",Disheveled");
    if (Details.IsInappropriatelyDressed) Sb_Appearance.Append(",Inappropriately Dressed");
    if (Details.IsAppearanceOther) Sb_Appearance.Append(",Other");
    var NewString = Sb_Appearance.ToString().TrimStart(',');
