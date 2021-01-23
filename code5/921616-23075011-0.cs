    public class Contact : EntityBase
    {
        private string _firstName;
        public string FirstName
        {
            get {return _firstName}
            set
              {
                  _firstName = value;
                  EntityState(); // maybe here must by ChangeState()
              }
        }
    
        private void ChangeState()
        {
           EntityState = EntityState.Modified;
        }
    }
