        [Key, Column(Order = 1)]
        public int? id { get; set; }
        [Required, Key, Column(Order = 2)]
        public virtual ParentModel parent { get; set; }
        [Required, MaxLength(128)]
        public string name { get; set; }
        public object ToJSON()
        {
            
                JavaScriptSerializer oSerializer = new JavaScriptSerializer();
                string sJSON = oSerializer.Serialize(this);
                return sJSON;
                //id = id,
                //name = name,
                //parent_id = parent.id
            
        }
    }
