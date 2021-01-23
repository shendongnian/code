    public static IEnumerable<int[]> Permute( params IEnumerable<int>[] sets )
	{
		if( sets.Length == 0 ) yield break;
		if( sets.Length == 1 ) 
		{
			foreach( var element in sets[0] ) yield return new[] { element };
			yield break;
		}
		
		var first = sets.First();
		var rest = Permute( sets.Skip( 1 ).ToArray() );
		var elements = first.ToArray();
		foreach( var permutation in rest )
		{
			foreach( var element in elements )
			{
				var result = new int[permutation.Length + 1];
				result[0] = element;
				Array.Copy( permutation, 0, result, 1, permutation.Length );
				yield return result;
			}
		}
	}
