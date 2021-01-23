        public int? RoleId
        {
            get { return this.Relationhip == null ? null : this.Relationhip.FirstOrDefault().TypeList.FirstOrDefault().Id();}
            set { RoleId = value; }
        }
