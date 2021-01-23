		public static void SortList<T>(ref List<T> list, String sortExpression, SortDirection sortDirection) {
			PropertyInfo propertyInfo = typeof(T).GetProperty(sortExpression);
			if (propertyInfo != null) {
				if (sortDirection == SortDirection.Ascending) {
					list.Sort(delegate(T t1, T t2) { return propertyInfo.GetValue(t1).ToString().CompareTo(propertyInfo.GetValue(t2).ToString()); });
				} else {
					list.Sort(delegate(T t1, T t2) { return propertyInfo.GetValue(t2).ToString().CompareTo(propertyInfo.GetValue(t1).ToString()); });
				}
				return;
			} else {
				foreach (var props in typeof(T).GetProperties()) {
					PropertyInfo pro = props.PropertyType.GetProperty(sortExpression);
					if (pro != null) {
						if (pro.Name.Equals(sortExpression)) {
							if (sortDirection == SortDirection.Ascending) {
								list.Sort(delegate(T t1, T t2) {
									return pro.GetValue(props.GetValue(t1)).ToString().CompareTo(pro.GetValue(props.GetValue(t2)).ToString());
								});
							} else {
								list.Sort(delegate(T t1, T t2) {
									return pro.GetValue(props.GetValue(t2)).ToString().CompareTo(pro.GetValue(props.GetValue(t1)).ToString());
								});
							}
							return;
						}
					}
				}
			}
		}
