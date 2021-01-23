                thistype =  typeof(BugManagerQueryOptions).GetProperty(items[i].ToString()).PropertyType.FullName;
                if (thistype == "System.String")
                {
                     typeof(BugManagerQueryOptions).GetProperty(items[i]).SetValue(currentSearch, properties[i], null);
                }
                else if (thistype == "System.Nullable`1[[System.Int64, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                {
                    long number = Int64.Parse(properties[i]);
                    typeof(BugManagerQueryOptions).GetProperty(items[i]).SetValue(currentSearch, number, null);
                    
                }
                else if (thistype == "System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]")
                {
                    int number = Int32.Parse(properties[i]);
                    typeof(BugManagerQueryOptions).GetProperty(items[i]).SetValue(currentSearch, number, null);
                }
