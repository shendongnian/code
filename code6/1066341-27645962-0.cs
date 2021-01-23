    public IEnumerable<object> Get()
            {
                try
                {
                    var database = new DABIREntities();
                    var query = database.noe_nameh.Take(1).Select(item => new
                    {
                        Id = item.uid,
                        Description = item.sharh
                    }).ToList();
                    return query;
                }
                catch (ReflectionTypeLoadException exception)
                {
                    return exception.LoaderExceptions.Select(item => item.Message).ToList();
                }
            }
