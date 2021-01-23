    var thelist = new[] {"1", "item", "10", "2", "3", "4", "5", "a", "b", "c"};
    		var list = thelist.Where( num => num.All( x => char.IsDigit( x ) ) )
                      .OrderBy( r => { int z; int.TryParse( r, out z ); return z; } )
    	              .Union( thelist.Where( str => str.All( x => !char.IsDigit( x ) ) )
                      .OrderBy( q => q ) );
    		
    		 foreach (var i in list)
                {
                    Console.WriteLine(i.ToString());
                    
                }
