    protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            tglDecimals.ItemSource=Your List;
            if (m_Settings.Contains(TOGGLE_DECIMALS_SETTING_KEY))
            {
                string decimalsToggleValue = (string)m_Settings[TOGGLE_DECIMALS_SETTING_KEY];
                string decimalsValue = (string)m_Settings[DECIMALS_SETTING_KEY];
    
                if (decimalsToggleValue == "On") 
                {
                    lpkDecimals.IsEnabled = true;
                    tglDecimals.IsChecked = true;
                    tblDecimals.Text = "On";
    
                    if (decimalsValue == "1") 
                    {
                        lpkDecimals.SelectedIndex = 0; // HERE IT CRASHES, WITH THE ERROR (SelectedIndex must always be set to a valid value.") 
                    }
                    else if (decimalsValue == "2")
                    {
                        lpkDecimals.SelectedIndex = 1; // HERE IT CRASHES, WITH THE ERROR (SelectedIndex must always be set to a valid value.") 
                    }
                    else if (decimalsValue == "3")
                    {
                        lpkDecimals.SelectedIndex = 2; // HERE IT CRASHES, WITH THE ERROR (SelectedIndex must always be set to a valid value.") 
                    }
                    else if (decimalsValue == "4")
                    {
                        lpkDecimals.SelectedIndex = 3; // HERE IT CRASHES, WITH THE ERROR (SelectedIndex must always be set to a valid value.") 
                    }
                    else if (decimalsValue == "5")
                    {
                        lpkDecimals.SelectedIndex = 4; // HERE IT CRASHES, WITH THE ERROR (SelectedIndex must always be set to a valid value.") 
                    }
                }
                else
                {
                    tglDecimals.IsChecked = false;
                    tblDecimals.Text = "Off";
                    lpkDecimals.IsEnabled = false;
                }
            }
            else
            {
                tglDecimals.IsChecked = false;
                tblDecimals.Text = "Off";
            }
            base.OnNavigatedTo(e);
        }
