    switch(myComboBoxThatICreatedInXaml.SelectedValue.ToString())
    {
        case "Low":
            QualityChoices.Add(YouTubeQuality.QualityHigh);
            break;
        case "Medium":
            QualityChoices.Add(YouTubeQuality.QualityMedium);
            break;
        case "High":
            QualityChoices.Add(YouTubeQuality.QualityHigh);
            break;
        default:
            break;
    } 
