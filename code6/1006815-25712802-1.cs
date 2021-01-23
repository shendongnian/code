    delegate void D(int x);
    class C
    {
    	public static void M1(int i) {...}
    	public static void M2(int i) {...}
    }
    class Test
    {
    	static void Main() {
    		D cd1 = new D(C.M1);		// M1
    		D cd2 = new D(C.M2);		// M2
    		D cd3 = cd1 + cd2;		// M1 + M2
    		D cd4 = cd3 + cd1; 		// M1 + M2 + M1
    		D cd5 = cd4 + cd3; 		// M1 + M2 + M1 + M1 + M2
    	}
    }
