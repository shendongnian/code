    private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
    {
         foreach (Control currentControl in this.Children)
         {
              if (currentControl.Tag == "CanToggle")
                   currentControl.Visible = !currentControl.Visible;
         }
    }
