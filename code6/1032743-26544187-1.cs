    var userDto = dbExamplesSet
                    .Select(e => e.OwningUser)
                    .Select(u => new UserDto
                    {
                        Id = u.Id, 
                        UserName = u.UserName
                    }).SingleOrDefault(u=> u.Id == someUserId);
