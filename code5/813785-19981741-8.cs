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
                model.Messages = _uow.MessageRepo.GetLastTenMessages(db.user_id);
                model.Groups = _uow.GroupRepo.GetGroups(db.user_id);
                return model
            }
        }
