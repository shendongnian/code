                using (var model = new MyEntities())
                {
                    System.Data.Entity.DbContext dbContext = model as System.Data.Entity.DbContext;
                    dbContext.Database.CommandTimeout = 6000;
                    model.CallProcedure1(idProcess);
                    model.CallProcedure2(idProcess);
                }
