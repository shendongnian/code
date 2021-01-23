My structure is: Dict([bool],object), ending with [bool] = true.
    		public void Init(bool[] boolArray)
			{
				BoolDict = new Dictionary<bool, object>();
				Dictionary<bool, object> parent = BoolDict;
				for (int index = 0; index < boolArray.Length; index++)
				{
					if (index < boolArray.Length - 1)
					{
						Dictionary<bool, object> nestedDict = new Dictionary<bool, object>();
						parent.Add(boolArray[index], nestedDict);
						parent = nestedDict;
					}
					else
					{
						parent.Add(boolArray[index], true);
					}
				}
			}
