    var propMetrics = (
        from e in doc.Descendants( "metric" )
        where !string.IsNullOrEmpty( e.Element( "value" ).Value )
        let auom = e.Attribute( "uom" )
        ).ToDictionary(
            e => e.Attribute( "name" ).Value,
            e => new {
                value = (double)e.Element( "value" ),
                uom = auom != null ? auom.Value : ""
            }
        );
