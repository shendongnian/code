    public kmlDom.Style createPlacemarkLineStyle ( kmlDom.Placemark placemark , bool highlight )
    {
      kmlDom.Style styleNode = new kmlDom.Style( );
      // Add Line Style
      kmlDom.LineStyle lineStyle = new kmlDom.LineStyle( );
      if( !highlight )
      {
        styleNode.Id = String.Format( "{0}-normal", placemark.placemarkName );
        lineStyle.Color = hexToColor("ff0000ff");
        lineStyle.Width = 2;
      }
      else
      {
	  styleNode.Id = String.Format( "{0}-highlight", placemark.placemarkName );
        lineStyle.Color = hexToColor( "ff0000ff" );
        lineStyle.Width = 2;
      }
      styleNode.Line = lineStyle;
      return styleNode;
    }
