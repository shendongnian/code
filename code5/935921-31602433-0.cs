    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    namespace WebAPIDemo
    {
    
    public class UserController : ApiController
    {
        static IUserRepository _repo = new UserRepository();
        // GET api/<controller>
        
        public IEnumerable<Users> GetAllUsers()
        {
            return _repo.GetAllUsers();            
        }
        // GET api/<controller>/5
        public IHttpActionResult GetUserById(int id)
        {
            
            return Json(_repo.GetUserById(id));
        }
