    public UserProfile LoadUserDetails(int userId) {
    	using (var context = new Context()) {
    		userProfile = context.UserProfile
    			.FirstOrDefault(x => x.UserId == userId);
    	}
    }
