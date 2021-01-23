    public List<int> highest(List<int> list, int number)
		{
            //probably a better way to do this
			IEnumerable<int> orderedList = list.OrderByDescending(item => item);
			var currentNumber = 0;
			List<int> combinationResult = new List<int>();
			foreach (var item in orderedList)
			{
				var temp = currentNumber + item;
				if (temp <= number)
				{
					combinationResult.Add(item);
					currentNumber = temp;
				}
			}
			return combinationResult;
		}
