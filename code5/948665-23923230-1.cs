    var propMetrics = (
        from e in doc.Descendants( "metric" )
        where !string.IsNullOrEmpty( e.Element( "value" ).Value )
        let auom = e.Attribute( "uom" )
        select new {
            key = e.Attribute( "name" ).Value,
            value = new {
                value = (double)e.Element( "value" ),
                uom = auom != null ? auom.Value : ""
            }
        } ).ToDictionary( p => p.key, p => p.value );
