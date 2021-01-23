    void CopyTableStyles( WordprocessingDocument source, WordprocessingDocument destination )
    		{
    			var sourceStyles = source.MainDocumentPart.StyleDefinitionsPart.RootElement;
    			var tableStyle = sourceStyles.Descendants<Style>()
    								.Where<Style>( s => s.StyleName.Val == "Light List - Accent 11")
    								.First<Style>();
    			if ( tableStyle != null )
    			{
    				var destinationStyles = destination.MainDocumentPart.StyleDefinitionsPart.RootElement;
    				destinationStyles.AppendChild( tableStyle.CloneNode( true ) );
    				destination.MainDocumentPart.StyleDefinitionsPart.PutXDocument();
    			}
    			return;
    		}
   
