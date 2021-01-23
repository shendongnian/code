    var list = 
     List.GroupBy(x => x.PropA)
	 		.SelectMany(grp => new MyObject[] { grp.First() }
            .Concat(grp.Skip(1)
              .Select(x => new MyObject { 
                           PropA = String.Empty, 
                           PropB = String.Empty, 
                           PropC = x.PropC }
                      )
               )
             );
