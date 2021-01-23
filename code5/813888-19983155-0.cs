    class Thing {
        int A { get; set; }
        int B { get; set; }
        int C { get; set; }
    }
    class StoreStruct {  //  Not actually a struct!
        public readonly Thing thing1;
        public readonly Thing thing2;
        public readonly Thing thing3;
    }
