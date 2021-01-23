    [Route("/groups/{Id}"]
    public class UpdateGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
    }
    [RequiresAnyRole("Admin", "FullAccess")]
    [Route("/admin/groups/{Id}"]
    public class AdminUpdateGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CoverImageUrl { get; set; }
        public string Description { get; set; }
        //... other admin properties
    }
