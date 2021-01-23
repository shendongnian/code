            var mc = new MemoryCache("myTestCache");
            TestObject testObject= mc["myItem"] as TestObject;
            var count = mc.GetCount(); 
            
            // count == 0
            // testObject == null
