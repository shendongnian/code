    public class Magazine:INamedEntity,ITypedEntity
    {
        public int Id {get;set;}
        [MaxLength(250)]
        public string Name {get;set;}
        public MagazineType Type { get; set; }
        TypedEntity ITypedEntity.Type 
        {
            get
            {
                return this.Type;
            } 
            set 
            {
                this.Type = value as MagazineType; // or throw an exception if value
                                                   // is not a MagazineType 
            }
        }
    }
