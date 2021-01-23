    class AnimalEntity : EntityBase {
        public override int Type { 
            get { return base.Type; }
            set {
                if (!Enum.IsDefined(typeof(AnimalType), value))
                    throw new ArgumentException();
                
                base.Type = (int)value;
            }
        }
    }
