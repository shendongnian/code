        //If you are using EF it could look like
        //filter and sort arguments could be added here as well
        public HttpResponseMessage Get(int? id)  
        {
           if(id.HasValue)
           {
               return Request.CreateResponse(
                   HttpStatusCode.OK, 
                   Context.Users.SingleOrDefault<Users>(u => u.Id == id));              
           }
           var users = Context.Users.Select(apply filter).OrderBy(apply sort).ToList();
           return Request.CreateResponse(HttpStatusCode.OK, users);   
        }
