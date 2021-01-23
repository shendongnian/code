    static void Method(ref int i) {
        // doesn't need to set the value
    }
    static void Main() {
        int value;
        value = 42; // needs to be initialised before the call
        Method(ref value);
       // value is still 42
    }
