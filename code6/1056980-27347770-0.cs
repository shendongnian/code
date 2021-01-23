        private ICollection<Material> materials;
        public virtual ICollection<Material> Materials
        {
            get { return materials ?? (materials = new List<Material>()); }
            set { materials = value; }
        }
