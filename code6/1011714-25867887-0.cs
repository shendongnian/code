    var hintStyle = new Style(typeof(ContentControl));
    hintStyle.Setters.Add(
       new Setter(
              System.Windows.Controls.Control.ForegroundProperty,
              view.PlaceholderTextColor.ToBrush())
              );
    phoneTextBox.HintStyle = hintStyle;
