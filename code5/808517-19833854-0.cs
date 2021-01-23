    public class A  {
    	public A(int prop1, int prop2, int prop3, int prop4, int prop5) {
    		Prop1 = prop1;
    		Prop2 = prop2;
    		Prop3 = prop3;
    		Prop4 = prop4;
    		Prop5 = prop5
    	}
        public int Prop1;
        public int Prop2;
        public int Prop3;
        public int Prop4;
        public int Prop5;
    }
    
    public class B : A {
    	public B(int prop1, int prop2, int prop3, int prop4, int prop5, int propB1, int propB2) : base(prop1, prop2, prop3, prop4, prop5) {
    		PropB1 = propB1;
    		PropB2 = propB2
    	}
    	public int PropB1;
    	public int PropB2;
    }
    
    public class C : A {
    	public C(int prop1, int prop2, int prop3, int prop4, int prop5, int propC1) : base(prop1, prop2, prop3, prop4, prop5) {
    		PropC1 = propC1;
    	}
    	public int PropC1;
    }
    var b = new B(param1, param2, param3, param4, param5, param6, param7);
    var c = new C(param1, param2, param3, param4, param5, param8);
