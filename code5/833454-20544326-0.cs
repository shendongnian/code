    var members =
                               _db.members
                               .Include(m =>m.homeTownCity)
                               .Include(m => m.currentCity)
                               .OrderBy(m => m.fname)
                               .ThenBy(m => m.lname).ToList();
   
    var model = members.Select(m => new MembersListViewModel
                               {
                                   homeTown = m.homeTownCity.Name,
                                   currentCity = m.currentCity.Name,
    
                                   //Calling a business class static method
                                   Name= MemberManagement.getFullname(m.lname,m.fname),
                                   spoken = m.spoken,
                                   hasPosted = m.posts.Count()
                               }).ToList();
