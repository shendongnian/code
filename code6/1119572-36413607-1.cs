    public class ModelBaseController<T> : ApiController where T : ModelBase 
    {
        [HttpPost]
        public void Post(T model)
        {
            ...
        }
    }
    public class CustomerModelController : ModelBaseController<CustomerModel>
    {
    }
    public class CustomerDetailsModelController : ModelBaseController<CustomerDetailsModel>
    {
    }
