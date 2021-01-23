			Variables v = new Variables();
			var a = new List<int>{ 1, 2, 3, 4, 5, 6 , 7};
			for (int i = 0; i < a.Count; i++)
			{
				String propertyName = "Variable" + i;
				Type myType = v.GetType();
				try
				{
					myType.GetProperty(propertyName).SetValue(v, a[i].ToString());
				}
				catch (NullReferenceException nre)
				{
					Console.WriteLine("Cannot Find Property");
				}
			}
