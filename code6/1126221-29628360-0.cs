       private delegate int _add(int a, int b);
        private _add add;
        private delegate int _calc(int a, int b, FakedEnum c); // nothing works here
        private _calc calc;
        public enum FakedEnum
        {
           
        }
        public void Run()
        {
            SetUp();
            add = GetExpectedFunction<_add>("add");
            int three = add(1, 2); // OK
            calc = GetExpectedFunction<_calc>("calc"); // not OK
        var result=    calc(4, 6, (FakedEnum)0);
            // intended usage
           // var reflectedEnum = ReflectMe("testEnum", "add");
            //int threeAgain = calc(1, 2, reflectedEnum);
        }
