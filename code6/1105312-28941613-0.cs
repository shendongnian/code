           if(property.GetValue(this,null) is IList 
                && property.GetValue(this,null).GetType().IsGenericType){
                var listType = property.PropertyType.GetGenericArguments()[0];
				var confType = typeof(ConfEntryList<>).MakeGenericType(listType);
				var item = Activator.CreateInstance(confType,
                      new object [] {property.Name, property.GetValue(this, null)});
				confContainer.ConfEntries [i] =  item;
           }
