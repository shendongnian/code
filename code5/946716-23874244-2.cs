    class Rabbit : WithBehaviors<Rabbit> {
        public Rabbit() {
            RegisterBehaviour(Behaviors.Jump, r => r.XVal += 10);
            RegisterBehaviour(Behaviors.Crouch, r => r.XVal -= 10);
        }
        public int XVal { get; private set; }
    }
