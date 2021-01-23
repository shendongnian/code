    redCheckBox.Tag = Color.Red;
    blueCheckBox.Tag = Color.Blue;
    // etc...
    
    List<Color> colors = new List<Color>();
    foreach (Object control in checkboxContainer.Children)
    { 
      var c = (control as CheckBox);
      if ( null == c )
        continue;
      colors.Add(c.Tag as Color);
    } 
