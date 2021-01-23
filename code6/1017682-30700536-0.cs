    [DllExport("Test", CallingConvention = CallingConvention.StdCall)]
    public static void TestOne() {
        MessageBox.Show("Test 1");
    }
    
    [DllExport("Test2", CallingConvention = CallingConvention.StdCall)]
    public static void TestTwo() {
        MessageBox.Show("Test 2");
        TestOne();
        //TestThree();
    }
    
    public static void TestThree() {
        MessageBox.Show("Test 3");
    }
