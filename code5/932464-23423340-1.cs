    var city="London";
    var url = String.Format(
                "http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&mode=xml&units=metric&cnt=17"
                , city);
    
    string temperature = String.Empty;
    string  day ="2014-05-02";
    
    using(var wc = new WebClient())
    {
        using(var stream = wc.OpenRead(url))
        {
            using(var myXmlReader = new XmlTextReader(stream))
            {
                while (myXmlReader.Read())
                {
                     // <time day="2014-05-01">
                    if (myXmlReader.NodeType == XmlNodeType.Element 
                        && myXmlReader.Name == "time"
                        && myXmlReader.HasAttributes
                        && myXmlReader.GetAttribute("day") == day)
                    {
                        // find the inner elements    
                        while (myXmlReader.Read())
                        {
                            // skip <symbol> <precipitation> <windDirection>  
                            //  and <windSpeed>
                            if (myXmlReader.NodeType == XmlNodeType.Element 
                                && myXmlReader.Name == "temperature"
                                && myXmlReader.HasAttributes
                                && myXmlReader.GetAttribute("day") != null)
                            {
                                // <temperature day="7.83" min="6.76" max="7.83" 
                                //   night="6.76" eve="7.83" morn="7.83"/>
                                temperature = myXmlReader.GetAttribute("day"); 
                            }
                        }
                    }
                }
            }
        }
    }
