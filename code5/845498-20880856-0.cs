    public Array ListToArray(List<Object> list)
    {
        // assume there is at least one element in list
       	Array arr = Array.CreateInstance(list[0].GetType(), list.Count);
    	Array.Copy(list.ToArray(), arr, list.Count);
    	return arr;
    }
