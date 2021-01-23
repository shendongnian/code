        void ActionParameter_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            ToolTipService.SetIsEnabled(img, true);
            // Uncomment if you want to immediately open it
            // ((ToolTip)img.ToolTip).IsOpen = true;
            ...
        }
