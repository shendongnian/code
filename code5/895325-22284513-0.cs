        public enum A
        {
            ONE,TWO
        };
        public enum B
        {
            THREE,
            FOUR
        };
        public Enum GetThing(int version)
        {
            return version == 1 ? (Enum)A.ONE : B.THREE;
        }
        public void DoThing()
        {
            Enum e = GetThing(1);
            if (e is A)
            {
                // handle A
                A _a = (A)e;
            }
            else
            {
                // handle B
            }
        }
