	class BaseElement {
	    public static final Property<BaseElement> P1 = new Property<BaseElement>();
	}
	class DerivedElement1 extends BaseElement {
	    public static final Property<DerivedElement1> P2 = new Property<DerivedElement1>();
	}
	class DerivedElement2 extends BaseElement {
	    public static final Property<DerivedElement2> P2 = new Property<DerivedElement2>();
	}
	class Property<Owner> {
	}
	class Proxy<Target> {
	}
	class App {
		static <Target>
		void doSomething(Proxy<? extends Target> proxy, Property<Target> property) {
        	// ...
		}
		static void main(String[] args) {
	        Proxy<DerivedElement1> proxy1 = new Proxy<DerivedElement1>();
	
	        doSomething(proxy1, DerivedElement1.P1);
	        doSomething(proxy1, DerivedElement1.P2);
	
	        // expected error
	        doSomething(proxy1, DerivedElement2.P2);
		}
	}
