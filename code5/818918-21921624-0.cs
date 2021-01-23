    static class myLogicExtensions {
        public static bool Implies(this bool a, bool b){
            return !a || b;
        }
    }
