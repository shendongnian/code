    public interface IAuditable
    {
        /// <summary>
        /// System fields who contain change and status information
        /// </summary>
        SystemFields SystemFields { get; set; }
    }
    [ComplexType]
    public class SystemFields
    {
        /// <summary>
        /// When has this entry be created
        /// </summary>
        [Required]
        public DateTime SysCreationDate { get; set; }
        /// <summary>
        /// Who has created the entry
        /// </summary>
        [Required]
        public string SysCreationUser { get; set; }
        /// <summary>
        /// When has this entry been modified
        /// </summary>
        public DateTime? SysModificationDate { get; set; }
        /// <summary>
        /// Who has updated the entry
        /// </summary>
        [CanBeNull]
        public string SysModificationUser { get; set; }
        /// <summary>
        /// Which activity has created/changed this entry
        /// </summary>
        [Required]
        [StringLength(32)]
        public string SysActivityCode { get; set; }
    }
