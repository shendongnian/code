    public abstract class Monster {
        public static Monster Create() {  // "Create" could have some parameters if needed.
            return new CuteMonster(); // you could change this without having to change client code.
        }
    }
