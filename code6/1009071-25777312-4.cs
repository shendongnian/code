    public class YourControllerName:apiController
    {
        public IQueryable<AnyNameListDTO> Get()
        {
            //Your other Code will go here 
            var session = HttpContext.Current.Session;
            if (session != null)
            {
                if (session["AnyName"] == null)
                {
                    session["AnyName"] = TheRepository.YourMethodName();
                }
            }
        }
    }
