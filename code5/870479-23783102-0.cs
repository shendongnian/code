    public class TestOdataController : OdataController
        {
            //GET odata/TestOdata       
            public IQueryable<ViewTest> Get()
            {
                try
                {
                    return context.View_TestRepository.GetQueryable();
                }
                catch (Exception ex)
                {
                   throw ex;               
                }
            }
        }
