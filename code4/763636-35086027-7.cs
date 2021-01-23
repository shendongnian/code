    public T SelectedRadioValue<T>(T defaultValue, params RadioButton[] buttons)
    {
        foreach (RadioButton button in buttons)
        {
            if (button.IsChecked == true)
            {
                if (button.Tag is string && typeof(T) != typeof(string))
                {
                    string value = (string) button.Tag;
                    return (T) Convert.ChangeType(value, typeof(T));
                }
                    
                return (T)button.Tag;
            }
        }
        return defaultValue;
    }
