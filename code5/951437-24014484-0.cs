        public int value1 {get;set;}
        public int value2 {get;set;}
        //if you see the below I am using this
        public void method1()
        {
            Console.Write(string.Format("value1: {0} value2: {1}", this.value1, this.value1));
        }
        public static void method2()
        { 
         //I callnot access my properties it self :(
         //and cannot be accesed
        }
