    using System.Collections.Generic;
    string line = "12,34";
    var dDataList = new List<KeyValuePair<double, double>>();
    string[] parts = line.Split( ',' );
    dDataList.Add( new KeyValuePair<double, double>( Double.Parse( parts[0] ), Double.Parse( parts[1] ) ) );
    ...
    foreach( var pair in dDataList )
        Console.WriteLine( "{0} => {1}", pair.Key, pair.Value ); // 12 => 34
