     [Authorize(Roles = GROUP)]
      [HandleError(ExceptionType = typeof(UnauthorizedAccessException), View = "ApplicationError")]
        public void Auth()
        {
            /* if user is in the domain and signed in
             * and a member of the above group 
             * they will come here */
    
            username = User.Identity.Name;
    
            //Do somthing
        }
