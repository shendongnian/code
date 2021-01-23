    public class ModUserEvents : IUserEventHandler {
    	public ModUserEvents() {
    	}
    
    	public void LoggedIn(IUser user) {
    		// go go do your stuff
    	}
    
    
    	#region unused events
    	public void Approved(IUser user){
    	}
    
    	public void Created(UserContext context){
    	}
    	
    	public void Creating(UserContext context) {
    	}
    
    	public void LoggedOut(IUser user) {
    	}
    
    	public void AccessDenied(IUser user) {
    	}
    
    	public void ChangedPassword(IUser user) {
    	}
    
    	public void SentChallengeEmail(IUser user) {
    	}
    
    	public void ConfirmedEmail(IUser user) {
    	}
    	#endregion
    }
