    public class BusinessController<T> : ApiController
    {
        ISomeService _someBusiness;
    
        public TestController(ISomeService someBusiness)
        {
            _someBusiness = someBusiness;
        }
    
        public T GetModelObject(ind id)
        {
            return _someBusiness.GetSomeModelObject(id);
        }
    
    }
