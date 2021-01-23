    public class UserViewModel
    {
        readonly User _user;
        readonly User _model;
        public UserViewModel(User user, OtherData data)
        {
            _user = user;
        }
        public User User
        { 
            get { return _user; }
        }
        
        public OtherData Data
        { 
            get { return _data; }
        }    
        [Required(ErrorMessage = "Id is requred")]
        public Guid Id 
        { 
            get { return _user.Id; }
            set { _user.Id = value; } 
        }
    
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name is required")]  
        public string Name     
        { 
            get { return _user.Name; }
            set { _user.Name = value; } 
        } 
      
        // TODO: Add OtherData fields you want to expose to view
    }
