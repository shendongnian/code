    public class Entity
    {
        private TypeMask _typeMask;
        
        [Key]
        public int Id { get; set; }
        public string TypeMaskString { get; set; }
        
        [NotMapped]
        public TypeMask Mask
        { 
            get
            {
                if (this._typeMask == null && !string.IsNullOrEmpty(TypeMaskString))
                {
                    this._typeMaks = new TypeMask(this.TypeMaskString);
                    // Or some other way to create a TypeMask from string.
                }
                return this._typeMask;
            } 
            set
            {
                this._typeMask = value;
                this.TypeMaskString = value.ToString();
            } 
        }
    }
