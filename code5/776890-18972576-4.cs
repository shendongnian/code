        public class UserViewModel
        {
            private Users _model;
            public UserViewModel(Users model)
            {
                _model = model;
            }
            public int Id { get { return _model.Id; } }
            public string Login { get { return _model.Login; } set { _model.Login; } }
            public string Name { get { return _model.Name; } set { _model.Name; } }
        }
