    public kmlDom.StyleSelector createPlacemarkLineStyleMap ( kmlDom.Placemark  placemark , kmlDom.Style normalStyle , kmlDom.Style highlightStyle )
    {
      // Set up style map
      kmlDom.StyleMapCollection styleMapCollection = new kmlDom.StyleMapCollection( );
      styleMapCollection.Id = String.Format( "{0}-stylemap" , placemark.placemarkName );
      // Create the normal line pair
      kmlDom.Pair normalPair = new kmlDom.Pair();
      normalPair.StyleUrl = new Uri(String.Format("#{0}", normalStyle.Id), UriKind.Relative);
      normalPair.State = kmlDom.StyleState.Normal;
      // Create the highlight line pair
      kmlDom.Pair highlightPair = new kmlDom.Pair( );
      highlightPair.StyleUrl = new Uri( String.Format( "#{0}" , highlightStyle.Id ) , UriKind.Relative );
      highlightPair.State = kmlDom.StyleState.Highlight;
      // Attach both pairs to the map
      styleMapCollection.Add( normalPair);
      styleMapCollection.Add( highlightPair );
      return styleMapCollection;
    }
