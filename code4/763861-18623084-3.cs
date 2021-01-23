    public class UserViewModel
    {
        // use this metadata to determine how to handle properties on this member
        [Flatten]
        public UserModel User { get; set; }
    
        public SelectList DescentTypes { get; set; }
        public SelectList GenderTypes { get; set; }
    }
