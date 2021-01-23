    		public static List<T> ToList<T>(this IDataReader dr) where T: new()
		{
			var col = new List<T>();
			var type = typeof(T);
			var props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			while (dr.Read())
			{
				var obj = new T();
				for (int i = 0; i < dr.FieldCount; i++)
				{
					string fieldName = dr.GetName(i);
					var prop = props.FirstOrDefault(x => x.Name.ToLower() == fieldName.ToLower());
					if (prop != null)
					{
						if (dr[i] != DBNull.Value)
							prop.SetValue(obj, dr[i], null);
					}
				}
				col.Add(obj);
			}
			dr.Close();
			return col;
		}
