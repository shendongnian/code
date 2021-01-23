    public partial class provider
    {
        public provider()
        {
            this.provider_contracts = new HashSet<provider_contracts>();
            this.provider_clinics = new HashSet<provider_clinics>();
            this.provider_custom_field_validations = new HashSet<provider_custom_field_validations>();
            this.provider_directory_languages = new HashSet<provider_directory_languages>();
            this.provider_directory_services = new HashSet<provider_directory_services>();
            this.provider_employees = new HashSet<provider_employees>();
            this.provider_field_exceptions = new HashSet<provider_field_exceptions>();
            this.provider_languages = new HashSet<provider_languages>();
            this.provider_required_fields = new HashSet<provider_required_fields>();
            this.provider_users = new HashSet<provider_users>();
            this.user_privileges = new HashSet<user_privileges>();
        }
    
        public virtual ICollection<provider_contracts> provider_contracts { get; set; }
        public virtual ICollection<provider_clinics> provider_clinics { get; set; }
        public virtual ICollection<provider_custom_field_validations> provider_custom_field_validations { get; set; }
        public virtual ICollection<provider_directory_languages> provider_directory_languages { get; set; }
        public virtual ICollection<provider_directory_services> provider_directory_services { get; set; }
        public virtual ICollection<provider_employees> provider_employees { get; set; }
        public virtual ICollection<provider_field_exceptions> provider_field_exceptions { get; set; }
        public virtual ICollection<provider_languages> provider_languages { get; set; }
        public virtual provider_options provider_options { get; set; }
        public virtual ICollection<provider_required_fields> provider_required_fields { get; set; }
        public virtual ICollection<provider_users> provider_users { get; set; }
        public virtual ICollection<user_privileges> user_privileges { get; set; }
    }
