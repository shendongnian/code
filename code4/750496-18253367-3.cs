    class PetOwner : ICry // The petowner has decide to Cry himself
    {
        public ICry ICry {get{return this;}}
        public string Cry { get { return "Hello!"; } }
    }
