    namespace pgl.businesslayer.ViewModels
    {
        public class UserInfo
        {
            // Default constructor
            public UserInfo()
            {
                userData = new pgl.businesslayer.Dto.pglUser();
            }
            // user info
            public pgl.businesslayer.Dto.pglUser userData { get; set; }
            // salon info
            public List<pglSalon> salonsData { get; set; }
            // company info
            public pglCompany companyData { get; set; }        
        }
    }
