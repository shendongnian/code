    var stateRad= IsRadTextBoxVisible;
    var stateSlider = IsSliderFontRotateVisible;
    var ........
    var ........
    IsCountriesListBoxVisible = false;
    IsSliderFontSizeVisible = false;
    IsSliderFontRotateVisible = false;
    IsRadTextBoxVisible = false
    switch (control)
    {
        case TextControl.TextBox:
            IsRadTextBoxVisible = !stateRad
            break;
        case TextControl.Font:
            IsCountriesListBoxVisible = !statexxx
            break;
        case TextControl.Size:
            IsSliderFontSizeVisible = !statexxx
            break;
        case TextControl.Rotate:
            IsSliderFontRotateVisible = !statexxx
            break;
        default:
            break;
    }
