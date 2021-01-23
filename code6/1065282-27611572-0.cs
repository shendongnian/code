    // add reference to System.ComponentModel.DataAnnotations to your project
    public class User
    {
        public int UserId { get; set; }
        // pass the "key" of the resource entry and the name of the resource file
        [Display(Name = "FullName", ResourceType = typeof(UserResources))]
        public string FullName { get; set; }
        [Display(Name = "FullAddress", ResourceType = typeof(UserResources))]
        public string FullAddress { get; set; }
        public string OtherProp { get; set; }
    }
