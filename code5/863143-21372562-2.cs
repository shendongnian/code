    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// The unique User GUID
        /// </summary>
        [NotMapped]
        public Guid ID
        {
            get { return Guid.Parse(this.Id); }
            set { this.Id = value.ToString(); }
        }
    
        /// <summary>
        /// weak userid reference. Use the property <seealso cref="WebApplication6.Models.ID"/> instead
        /// </summary>
        public override string Id { get { return base.Id; } set { base.Id = value; } }
    }
