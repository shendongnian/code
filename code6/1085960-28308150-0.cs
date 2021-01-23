    public class VerifyRequestedSystemsAttribute : Attribute, IHasRequestFilter
    {
        public IDbConnectionFactory DbFactory { get; set; }
    
        private List<int> RetrieveSystemIds(object requestDto)
        {
            using (var db = DbFactory.OpenConnection())
            {
                //...
            }
        }
    }
