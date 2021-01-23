    Series series = new Series();
    series.type = "foo";
    series.name = "bar";
    series.data = new List<object>();
    for( int i = 0; i < 5; i++ )
    {
        series.data.Add( DateTime.Now );
        series.data.Add( i );
    }
    var json = JsonConvert.SerializeObject( series );
