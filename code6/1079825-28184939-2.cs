    public class AddUserViewModel
    {
        [CustomEmail]
        public string Email { get; set; }
        [CustomEmail]
        public string RetypeEmail { get; set; }
    }
