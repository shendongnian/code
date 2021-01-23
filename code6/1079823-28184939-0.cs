    // Base class. That will be shared by the add and edit
    public class UserModel
    {
        public int ID { get; set; }
        public virtual string FirstName { get; set; } // Notice the virtual?
        // This validation is shared on both Add and Edit.
        // A centralized approach.
        [Required]
        public string LastName { get; set; }
    }
    // Used for creating a new user.
    public class AddUserViewModel : UserModel
    {
        // AddUser has its own specific validation for the first name.
        [Required]
        public override string FirstName { get; set; } // Notice the override?
    }
    // Used for updating a user.
    public class EditUserViewModel : UserModel
    {
        public override string FirstName { get; set; }
    }
