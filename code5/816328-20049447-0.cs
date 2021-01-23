    private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      // MyBarcodeScanner would be a reference to the IInput device that represents the scanner:
      if (e.Device == MyBarcodeScanner)
      {
        // Process the text.
      }
      else
      {
        // This is some other keyboard, ignore it, or whatever.
      }
    }
