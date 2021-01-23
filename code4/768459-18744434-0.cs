    public static class TextBoxBehaviors
    {
    public static readonly DependencyProperty AlphaNumericOnlyProperty = DependencyProperty.RegisterAttached(
      "AlphaNumericOnly", typeof(bool), typeof(TextBoxBehaviors), new UIPropertyMetadata(false, OnAlphaNumericOnlyChanged));
    static void OnAlphaNumericOnlyChanged(DependencyObject depObj, DependencyPropertyChangedEventArgs e)
    {
      var tBox = (TextBox)depObj;
      if ((bool)e.NewValue)
      {
        tBox.PreviewTextInput += tBox_PreviewTextInput;
      }
      else
      {
        tBox.PreviewTextInput -= tBox_PreviewTextInput;
      }
    }
    static void tBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
    {
      // Filter out non-alphanumeric text input
      foreach (char c in e.Text)
      {
        if (AlphaNumericPattern.IsMatch(c.ToString(CultureInfo.InvariantCulture)))
        {
          e.Handled = true;
          break;
        }
      }
    }
    }
