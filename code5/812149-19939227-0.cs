    class Car
    {
        // ...other members 
    
        // User-defined conversion from TCar to Car
        public static implicit operator Car(TCar d)
        {
            return new Car(d);
        }
        //  User-defined conversion from Car to TCar
        public static implicit operator TCar(Car d)
        {
            return new TCar(d);
        }
    }
