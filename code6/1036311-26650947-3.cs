    public SmallUserProfile LoadUserDetails(int userId) {
    	using (var context = new Context()) {
    		userProfile = context.UserProfile
    			.Where(x => x.UserId == userId)
    			.Select(x => new SmallUserProfile {
    			    UserId = x.userId,
    			    // etc...
    			})
    			.AsEnumerable()
    			.Select(x => new SmallUserProfile {
    			    UserId = x.userId,
    			    // etc...
    			})
    			.FirstOrDefault();
    	}
    }
