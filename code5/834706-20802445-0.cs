        public class Owner()
        {
            public int OwnerTypeId { get; set; }
        
            public OwnerType OwnerType
            {
                get 
                { 
                    return StaticClass.OwnerTypes
                        .FirstOrDefault(p => p.Id == this.OwnerTypeId);
                }
    
                set
                {
                    if (value != null)
                        OwnerTypeId = value.Id;
                }
            }
        }
