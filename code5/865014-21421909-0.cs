        private string RolesInternal { get; set; }
        [NotMapped]
        public List<string> Roles
        {
            get { return RolesInternal.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries).Select(t => t).ToList(); }
            set { RolesInternal = string.Join(",", value); }
        }
