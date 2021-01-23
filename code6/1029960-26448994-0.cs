    namespace SomeNamespace {
        class SomeClass {
            public int field1 { get; set;}
            public int field2 { get; set;}
        }
    
        class OtherClass {
            SomeClass sc = new SomeClass();
    		// frist set the values
    		sc.field1 = 1;                    
            sc.field2 = 2;                    
    		// then read them 
            int field1 = sc.field1;           
            int field2 = sc.field2;           
            
        }
    }
