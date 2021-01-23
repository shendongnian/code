    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using UserDataAccess;
    
    namespace SBPMS.Controllers
    {
        public class UsersController : ApiController
        {
        
    
            public IEnumerable<User> Get() {
                using (SBPMSystemEntities entities = new SBPMSystemEntities()) {
                    entities.Configuration.ProxyCreationEnabled = false;
                    return entities.Users.ToList();
                }
            }
            public User Get(int id) {
                using (SBPMSystemEntities entities = new SBPMSystemEntities()) {
                    entities.Configuration.ProxyCreationEnabled = false;
                    return entities.Users.FirstOrDefault(e => e.user_ID == id);
                }
            }
        }
    }
