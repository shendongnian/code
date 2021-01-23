    // create filter
    EuclideanColorFiltering filter = new EuclideanColorFiltering( );
    // set center colol and radius
    filter.CenterColor = new RGB( 215, 30, 30 );
    filter.Radius = 100;
    // apply the filter
    filter.ApplyInPlace( image );
