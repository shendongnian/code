    appHost.RequestFilters.Add( ( req, res, obj ) =>
        {
            if(!req.Items.ContainsKey( "begin-time" ) )
                req.Items.Add( "begin-time", DateTime.Now );
            else
                req.Items[ "begin-time" ] = DateTime.Now;
        }
    );
    
    appHost.ResponseFilters.Add( ( req, res, i ) =>
        {
            var beginTime = (DateTime)req.Items[ "begin-time" ];
    
            var elapsed = DateTime.Now - beginTime;
        }
    );
