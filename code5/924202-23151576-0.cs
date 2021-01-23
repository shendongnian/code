    var Results = bugAndFeatures.ToList().OrderBy(p => p.EmployeeFullName);
     IQueryable<Foo> query = ...;
     switch (orderByParameter)
                    {
                        case "SomeValueParamter":
                            query = query.OrderBy(x => x.SomeValueParamter);
                            break;
                        case "SomeValueParamter":
                            query = query.OrderBy(x => x.SomeValueParamter);
                            break;
                        // etc
                    }
