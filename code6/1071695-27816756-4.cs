    var list = 
     List.GroupBy(x => x.PropA)
	 		.SelectMany(grp => new MyObject[] { grp.First() }
            .Concat(grp.Skip(1)
              .Select(x => { x.PropA = String.Empty; x.PropB = String.Empty; return x; } })
               )
             );
