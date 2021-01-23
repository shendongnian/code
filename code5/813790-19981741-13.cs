    public class UserService
    {
        private UnitOfWork _uow;
        public UserService(UnitOfWork uow)
        {
            _uow = uow;
        }
        public MyModel GetSentMessages()
        {
                MyModel model = new MyModel();
                model.Messages = _uow.MessageRepo.GetLastTenMessages();
                model.Groups = _uow.GroupRepo.GetGroups();
                return model
            }
        }
