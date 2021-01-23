    	public static void AssertArePropertiesEqual<T>(T expectedObj, T actualObj, params string[] ignore) where T : class
		{
			if (expectedObj != null && actualObj != null)
			{
				var type = typeof(T);
				if (type.IsPrimitive || type == typeof(string))
				{
					Assert.AreEqual(expectedObj, actualObj);
					return;
				}
				var ignoreList = new List<string>(ignore);
				foreach (var pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
				{
					if (ignoreList.Contains(pi.Name)) continue;
					var selfValue = type.GetProperty(pi.Name).GetValue(expectedObj, null);
					var toValue = type.GetProperty(pi.Name).GetValue(actualObj, null);
					var selfValueDate = selfValue as DateTime?;
					var toValueDate = toValue as DateTime?;
					if (selfValueDate.HasValue && toValueDate.HasValue)
					{
						Assert.IsTrue(Math.Abs((selfValueDate.Value - toValueDate.Value).TotalSeconds) < 1,
									  string.Format("The compare of [{0}] properties failed. Expected Date:{1}  Actual Date: {2}", pi.Name,
													selfValueDate, toValueDate));
					}
					else
					{
						Assert.AreEqual(selfValue, toValue, string.Format("The compare of [{0}] properties failed.", pi.Name));
					}
				}
				return;
			}
			Assert.AreEqual(expectedObj, actualObj);
		}
