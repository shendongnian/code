    public class UserRepository
    {
        public IList<User> GetAllUsersWithJourneys()
        {
             //Fetch all Users; Include Journeys 
        }
    }
    public class JourneyRepository
    {
        public IList<Journey> GetAllJourneysWithUsers()
        {
             //Fetch all journeys; Include Users 
        }
    }
