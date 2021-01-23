                     if (entity.SearchName == "LastFirstName")
                    {
                        //// Construct Expressions to hold the propert values
                        Expression lastNameExp = Expression.PropertyOrField(param, "LastName");
                        Expression firstNameExp = Expression.PropertyOrField(param, "FirstName");
                        
                        //// Construct a String.Concat method. 
                        MethodInfo methodInfo = typeof(string).GetMethod("Concat", new Type[] { typeof(string), typeof(string) });
                        //// Combine the LastName + FirstName for the compare
                        MethodCallExpression combinedExp = Expression.Call(methodInfo, lastNameExp, firstNameExp);
                                                
                        
