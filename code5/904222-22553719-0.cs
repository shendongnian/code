    public class CompanyReference : EntityReference<CompanyReference>
    {
        #region Public Properties
        /// <summary>
        /// name
        /// </summary>
        [StringLength(8)]
        [Required]
        public string Name
        {
            get;
            protected set;
        }
        /// <summary>
        /// displayname
        /// </summary>
        [StringLength(45)]
        public string DisplayName
        {
            get;
            protected set;
        }
        #endregion
    }
