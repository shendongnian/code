    public sealed class UserRequests{
    
         private static readonly UserRequests instance = new UserRequests();
         public static UserRequests Instance { get { return instance; } }
    
         static UserRequests() {}
         private UserRequests() {}
        
        private Dictionary<Users,List<DateTime>> _userRequestList;
        
        private void AddRequest(User user){
            //Add request to internal collection
        }
        public bool CanUserMakeRequest(User user){
           //Call clean up method to remove old requests for this user        
    
           // check the requests to see if user has made too many 
           // if not call AddRequest and return true, else return false
        }
      }
