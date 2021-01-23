        //ForeignKey("<Navigation Property Name>")
        [Key, ForeignKey("ProfileMeta")] 
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int ProfileMetaID {get; set;}
        public virtual ProfileMeta ProfileMeta { get; set; }
