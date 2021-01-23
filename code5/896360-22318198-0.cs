    var list = "".AsEnumerable().Select(x => 
                {
                    var sampleObject = new ExpandoObject();
                    foreach (var col in columnsNames)
                    {
                        ((IDictionary<String, Object>)sampleObject)
                         .Add(col, x.Field<string>(col));
                    }
                    return sampleObject;
                }); 
