    private void labanglestart_TextChanged(object sender, TextChangedEventArgs e)
     {
     double a;
     
     if (double.TryParse(labanglestart.Text.ToString(), 
                     NumberStyles.Number,CultureInfo.InvariantCulture, 
                     out a))
     {
         Global2.Pat_anglestart = a;
     }
     else
     {
         labanglestart.Text = Global2.Pat_anglestart.ToString();
     }
     }
