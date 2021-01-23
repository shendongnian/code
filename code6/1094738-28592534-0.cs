        static bool IsFullyEqual(object obj1, object obj2)
		{
			if (obj1.GetType() != obj2.GetType()) return false;
			bool result = true;
			foreach (var property in obj1.GetType().GetProperties())
			{
				object obj1Value = property.GetMethod.Invoke(obj1, null);
				object obj2Value = property.GetMethod.Invoke(obj2, null);
				if( obj1Value.GetHashCode()!= obj2Value.GetHashCode())
				{
					result = false;
					break;
				}
			}
			return result;
		}
