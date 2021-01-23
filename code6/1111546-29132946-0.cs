        ...
        HardwareButtons.BackPressed += HardwareButtons_BackPressed;
    }
    private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
    {
        this.Frame.GoBack();
    }
