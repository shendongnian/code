    class MC {
        public void delegate Callback();
        public double method2(Callback f) {
            Console.WriteLine("Executing method2" );
            /* ... do f() at some point ... */
            /* also tried f.DynamicInvoke() */
            Console.WriteLine("Done executing method2" );
        }
    }
