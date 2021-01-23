     public class IdentityBase
        {
            /// <summary>
            /// Gets or sets ID.
            /// </summary>
            [NonNegative]
            [DataMember(IsRequired = true)]
            public int ID
            {
                get;
                set;
            }
    
            /// <summary>
            /// Gets or sets the unique identifier of a row; this is to do with replication in SQL.
            /// </summary>
          
            public Guid UniqueIdentifier
           { 
                get;
                set;
            }
