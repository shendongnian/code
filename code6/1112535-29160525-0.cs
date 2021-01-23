    class UserModel
    {
        public UserModel()
        {
            this.Department = new DepartmentModel();
        }
        public int Id { get; set; }
        public DepartmentModel Department { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
        public string MiddleName { get; set; }
        public string NameSuffix { get; set; }
        public string Type { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName(bool isFamilyNameFirst)
        {
            StringBuilder fullname = new StringBuilder();
            if(isFamilyNameFirst)
            {
                fullname.Append(FamilyName).Append(", ").Append(GivenName).Append(" ").Append(MiddleName).Append(" ").Append(NameSuffix);
            }
            else
            {
                fullname.Append(GivenName).Append(" ").Append(MiddleName).Append(" ").Append(FamilyName).Append(" ").Append(NameSuffix);
            }
            return fullname.ToString();
        }
    }
