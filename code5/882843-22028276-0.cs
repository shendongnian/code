                .ExcludeAssemblies(x =>
                    {
                        if (!x.GetName().FullName.StartsWith("Microsoft."))
                        {
                            return x.GetName().Name.Equals("Microsoft");
                        }
                        return true;
                    })
