        private int? roleId;
        public int? RoleId
        {
            get 
            { 
                 return (roleId = roleId.GetValueOrDefault(this.Relationhip == null ? null : this.Relationhip.FirstOrDefault().TypeList.FirstOrDefault().Id()));
            }
            set { roleId = value; }
        }
