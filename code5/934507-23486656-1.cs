	object[] prepare_row(string s1, string s2, double[] double_array, object some_object) {
		// Adding first 2 entries
		List<object> temp_list = new List<object> {s1, s2};
		// Adding your double arary
		foreach (var val in double_array)
		{
			temp_list.Add(val);
		}
		// Adding your anotherValue
		temp_list.Add(some_object);
		
		return  temp_list.ToArray();
	}
