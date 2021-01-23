    public SmallUserProfile LoadUserDetails(int userId) {
    	using (var context = new Context()) {
    		userProfile = context.UserProfile
    			.Where(x => x.UserId == userId)
    			.AsEnumerable()
    			.Select(x => new SmallUserProfile {
    			    UserId = userId,
    			    // etc...
    			})
    			.FirstOrDefault();
    	}
    }
