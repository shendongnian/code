    namespace WebInventory.Models
    {
        [DataContract]
        public class PostbackList
        {
            [DataContract]
            public class Field
            {
                public int ID {get; set;}
                public string Name {get; set;}
                public int DataTypeID {get; set;}
    
                public bool Checked {get; set;}
            }
    
            [DataMember]
            public int TypeID {get; set;}
    
            [DataMember]
            public IList<Field> Fields {get; set;}
    
            [DataMember]
            public IList<IList<string>> Values {get; set;}
    
            #region Non DataMember
            public IList<int> UsedFieldsID {get; set;}
            #endregion
        }
    }
