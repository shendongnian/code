    private void labanglestart_LostFocus(object sender, TextChangedEventArgs e)
        {
             double a;
             double.TryParse(labanglestart.Text.ToString(), NumberStyles.Number,CultureInfo.InvariantCulture, out a);
             if (a != null )
             {
                 Global2.Pat_anglestart = a;
             }
             else
             {
                 labanglestart.Text = Global2.Pat_anglestart.ToString();
             }
        }
