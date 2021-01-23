        private void changeControl(TextControl control)
        {
            IsRadTextBoxVisible = control == TextControl.TextBox ? !IsRadTextBoxVisible : false;
            IsCountriesListBoxVisible = control == TextControl.Font ? !IsCountriesListBoxVisible : false;
            IsSliderFontSizeVisible = control == TextControl.Size ? !IsSliderFontSizeVisible : false;
            IsSliderFontRotateVisible = control == TextControl.Rotate ? !IsSliderFontRotateVisible : false;
        }
