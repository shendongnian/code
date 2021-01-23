    public bool AllUserDetailsContainSomething(UserDetail userDetail){
    
     return userDetail.GetType().GetProperties()
            .Where(pi => pi.GetValue(userDetail) is string)
            .Select(pi => (string) pi.GetValue(userDetail))
            .All(value => !String.IsNullOrEmpty(value));
    
    } 
