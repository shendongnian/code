    		try
            {
                pcontext.SaveChanges();
            }
		   catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
            {             
                 Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.EntityCommandCompilationException ex)
            {
              Console.WriteLine(ex.InnerException);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
			 Console.WriteLine(ex.InnerException);
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
