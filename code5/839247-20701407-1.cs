        void ActionParameter_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ... // compute canDelete
            if (cantDelete)
            {
               Image img = (Image)sender;
               ToolTipService.SetIsEnabled(img, true);
               // Uncomment if you want to immediately open it
               // ((ToolTip)img.ToolTip).IsOpen = true;
            }
        }
