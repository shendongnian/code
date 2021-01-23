    var user = List
    .Select(e=>e.Split(",", StringSplitOptions.RemoveEmpty).Select(a=>
    new
     {
      Username = a[0].Trim(), 
      Password=a[1].Trim()
     }))
    .Where(o=>o.Username = Username /*username entered by the user*/)
    .SingleOrDefault();
    
    if(user!=null)
    {
      if(user.Password == Password /*password entered by the user*/) {/*Valid User*/}
      else{/*Invalid password OR Username*/}
    }
    else {/*User does not exist*/}
