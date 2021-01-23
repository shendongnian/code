    //we store list of indices with the same value in a dictionary
	Dictionary<double, List<int[]>> dictionary = new Dictionary<double, List<int[]>>();
	//loop over listVal
	for (int i = 0; i < listVal.Count; i++)
		for (int j = 0; j < listVal[i].Count; j++)
			for (int k = 0; k < listVal[i][j].Count; k++)
			{
				if (!dictionary.ContainsKey(listVal[i][j][k]))
				{
					//if the dictionary doesn't have value listVal[i][j][k] 
					//then add the value as key with the value's current index
					dictionary.Add(listVal[i][j][k], new List<int[]> { new int[] { i, j, k } });
				}
				else
				{
					//add more index of the same value to the index list
					dictionary[listVal[i][j][k]].Add(new int[] { i, j, k });
				}
			}
	foreach (var entry in dictionary)
	{
		//get list of all position having the same value
		List<int[]> indices = entry.Value;
		//do your process on listQ
		//sum values in listQ
		double sum = 0;
		foreach (var index in indices)
		{
			sum += listQ[index[0]][index[1]][index[2]];
		}
		//calculate average value
		double average = sum / indices.Count;
		//assign back to litsQ
		foreach (var index in indices)
		{
			listQ[index[0]][index[1]][index[2]]  = average;
		}
	}
