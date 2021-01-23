    class Data {
    	// Common properties
    	public aType varA;
        public bType varB;
        public cType varC;
    }
    
    class A extends Data {
    	// other properties
    }
    
    class B extends Data {
    	public dType varD;
    	// other properties
    }
    
    class DataTable {
    	Data data;
    	public DataTable(int selector) {
    		if (selector == 1) {
    			// data will contain table A
    		} else if (selector == 2) {
    			// data will contain table B
    		}
    	}
    	
    	public boolean isVarA() {
    		return data.varA;
    	}
    }
