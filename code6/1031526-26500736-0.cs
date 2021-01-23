    IsCountriesListBoxVisible = false;
    IsSliderFontSizeVisible = false;
    IsSliderFontRotateVisible = false;
    IsRadTextBoxVisible = false
    switch (control)
    {
        case TextControl.TextBox:
            IsRadTextBoxVisible = !IsRadTextBoxVisible 
            break;
        case TextControl.Font:
            IsCountriesListBoxVisible = !IsCountriesListBoxVisible   
            break;
        case TextControl.Size:
            IsSliderFontSizeVisible = !IsSliderFontSizeVisible             
            break;
        case TextControl.Rotate:
            IsSliderFontRotateVisible = !IsSliderFontSizeVisible 
            break;
        default:
            break;
    }
