    try
                {
                    pcontext.SaveChanges();
                }
                catch (System.Data.Entity.Core.UpdateException e)
                {
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException ex) //DbContext
                {
                    Console.WriteLine(ex.InnerException);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException);
                    throw;
                }
