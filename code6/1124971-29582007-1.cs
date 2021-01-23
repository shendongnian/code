         [DataContract]
         public class Mycontractclass
         {     
             // Apply the DataMemberAttribute to the property.
            [DataMember]
            public DateTime datereturn
            {
               get
               {
                  return this.dateCreated.HasValue
                     ? this.dateCreated.Value
                     : DateTime.Now;
               }
            
               set { this.dateCreated = value; }
            }
        
            private DateTime? dateCreated = null;
        }
