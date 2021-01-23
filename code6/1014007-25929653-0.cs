    using (var ds = new DSEntities())
                    {
                        Employee e = new Employee();
                        e.AccessProfileId = ds.AccessProfiles.First().Id;
                        ds.Employees.Add(e);
                        ds.SaveChanges();
                    }
