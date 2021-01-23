    public class User : MyModel
    {
        [NotPatchable]
        public int ID { get; set; }
        [NotPatchable]
        public bool Deleted { get; set; }
        public string FirstName { get; set; }
    }
