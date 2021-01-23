       public string GetArrayString()
            {
                var arrayValues = new object[]{
                    1,2,3,new[]{4,5,6}
                };
    
                return this.FormatArrayValues(arrayValues);
            }
    
            public string FormatArrayValues(IEnumerable<object> arrayValues)
            {
                String s = "{";
    
                arrayValues = arrayValues.Where(w=>w != null).ToArray();
    
                for(int j = 0; j < arrayValues.Count();j++){
    
                    var currentValue = arrayValues.ElementAt(j);
    
                    if(currentValue is int[])
                    {
                        var currentValueAsArrayOfObj = ((int[])currentValue).Cast<object>();
                        currentValue = this.FormatArrayValues(currentValueAsArrayOfObj);
                    }
    
                    s += String.Format("{0}:{1}{2}",j, currentValue, j + 1 != arrayValues.Count() ? "," : null);
    
                }
    
                s += "}";
    
                return s;
            }
