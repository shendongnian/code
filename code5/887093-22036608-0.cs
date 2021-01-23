    // Create the Button.
    Button originalButton = new Button();
    originalButton.Height = 50;
    originalButton.Width = 100;
    originalButton.Background = Brushes.AliceBlue;
    originalButton.Content = "Click Me";
    // Save the Button to a string. 
    string savedButton = XamlWriter.Save(originalButton);
    // Load the button
    StringReader stringReader = new StringReader(savedButton);
    XmlReader xmlReader = XmlReader.Create(stringReader);
    Button readerLoadButton = (Button)XamlReader.Load(xmlReader);
