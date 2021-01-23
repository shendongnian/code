    listBoxVandaagTop.ItemsSource = XmlSneeuw.Elements("top").Select( weather1=> new AlgemeneInformatieTop
          {
              Actueel_Top_maxtempC = weather1.Element("maxtempC").Value,
              Actueel_Top_mintempC = weather1.Element("mintempC").Value,
          });
