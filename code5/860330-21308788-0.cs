    //If you declare your style in a resource dictionary, get that resource first
    
ResourceDictionary resD = (ResourceDictionary)Application.LoadComponent(new Uri("ResourcesPlot\\ResourceDictionaryPlot.xaml", UriKind.Relative));
    
    //The actual style
            
    Style lineDataPointStyle= (Style)resD["LineDataPointStyle"];
    //Set the color
    lineDataPointStyle.Setters.Add(new Setter(BackgroundProperty, Utils.GenerateRandomColor()));
