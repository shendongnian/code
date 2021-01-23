     public class GenericController<T> : ApiController where T : BaseContext, new()
     {
        public string Get(int id) 
        {
            try
            {
                var obj = dataRepository.Get<T>(id);
                responseMessage.SetGetSuccess(obj);
            }
                catch (Exception e)
            {
                responseMessage.SetGetUnsuccess(e);
            }
            return responseMessage.ToJsonString();
        }
     }
