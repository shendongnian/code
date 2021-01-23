    var tuple = dt.Rows.Cast<DataRow>()
                       .Select(row => row["ColumnABC"].ToString().Split('/'))
     	               .Select(strs => new Tuple<int, int>(
				             Int32.Parse(strs[0]),
					         Int32.Parse(strs[1])))
	                   .Aggregate((curr, next) => new Tuple<int, int>(
    	                    curr.Item1 + next.Item1,
    	                    curr.Item2 + next.Item2));
    var result = String.Format("{0}/{1}", tuple.Item1, tuple.Item2);
