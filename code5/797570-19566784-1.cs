    [Route("/user")]
    [Route("/user/{Id}")]
    public class User : DynamicModel
    {
        public User(object dto)
            : base(dto)
        {
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
