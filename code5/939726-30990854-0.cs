     private void x(List<dynamic> dynamicList)
                {
                    Type typeInArgument = dynamicList.GetType();
                    Type newGenericType = typeof(List<>).MakeGenericType(typeInArgument);
                    IList data = (IList)JsonConvert.DeserializeObject(this._dataSourceValues[i], newGenericType);
                }
