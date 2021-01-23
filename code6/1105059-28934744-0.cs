    [Route("/services/{Type}/{PathInfo*})]
    public class DynamicService 
    {
        public string Type { get; set; }
        public string PathInfo { get; set; }
    }
    public class DynamicServices : Service
    {
        public object Any(DynamicService request)
        {
            if (request.Type == "type1") 
            {
                //Resolve existing Service and call with converted Request DTO
                using (var service = base.ResolveService<Type1Service>())
                {
                    return service.Any(request.ConvertTo<Type1Request>());
                }
            }
            else if (request.Type == "type2") { ... }
        }
    }
