    using (var context = new DbContext())
    {
        var usersWithServices = context.Users.GroupJoin(
    		context.UserServices,
    		u => u.Id,
    		j => j.UserId,
    		(user, @join) => new {
    			user,
    			@join
    		}).Select(a => 
    			a.join.GroupJoin(
    				context.Services,
    				j => j.ServiceId,
    				s => s.Id,
    				(@join, service) => new {
    					a.user,
    					@join,
    					service
    				})).ToList();
    }
