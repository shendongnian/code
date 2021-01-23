    public abstract ParentClass {
        public abstract int MyGetHashCode();
    
        public override int GetHashCode(){
            return MyGetHashCode();
        }
    
        // same thing for Equals
    }
