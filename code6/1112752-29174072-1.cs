     using (phoneDBContext db1 = new phoneDBContext())
                    {
                        IQueryable<Project> cityQuery = from c in db1.Projects
                                                        where c.Id == 56
                                                        select c;
                        Project p = cityQuery.FirstOrDefault();
                        p.Project_name = "rmlas";
                        db1.SubmitChanges();
                    }
