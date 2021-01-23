    public partial class Animal : Base Model
    {
        public virtual Owner Owner { get; set; }
        public virtual Protector Protector { get; set; }
        public string ActiveCareTacker
        {
            get
            {
                if (Owner != null && string.IsNullOrEmpty(Owner.Name) == false)
                    return Owner.Name;
                if (Protector != null && string.IsNullOrEmpty(Protector.Name) == false)
                    return Protector.Name;
                return "No Owner/Protector";
            }
        }
    }
