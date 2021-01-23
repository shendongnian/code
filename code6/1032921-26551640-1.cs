    public class ValuesController : ApiController
    {
        // Removes all filters applied globally or at the controller level
        [OverrideAuthentication]
        [MyAnotherAuthentication] // Puts back only MyAnotherAuthenticationFilter
        public string Post(...)
        { ... }
    }
