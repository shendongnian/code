    class Item {
        public string Name;
        public string Description;
        public int currentAmount;
    
        public override int GetHashCode(){
           return Name.GetHashCode() + Description.GetHashCode();
        }
    }
