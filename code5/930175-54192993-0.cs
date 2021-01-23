    /// <summary>
        /// Gets or sets the category attachment type
        /// </summary>
        public CategoryAttachmentType CategoryAttachmentType
        {
            get
            {
                return (CategoryAttachmentType)this.CategoryAttachmentTypeId;
            }
            set
            {
                this.CategoryAttachmentTypeId = (int)value;
            }
        }
