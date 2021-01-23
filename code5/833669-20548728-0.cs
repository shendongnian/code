    public class DoWorkController : ApiController{
        public User GetDoWork(String ID) {
            Dictionary<int, Work> users = DataObjects.Work.find(input);
            return users.Values.First<Work>();
        }
    }
