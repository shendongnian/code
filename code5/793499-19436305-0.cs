    class OutputClass{
        private int var1;
        private int var2;
        int getVar1()
        {
            return var1;
        }
        int getVar2()
        {
            return var2;
        }
        protected OutputClass(int _var1, int _var2)
        {
            var1 = _var1;
            var2 = _var2;
        }
    }
    class APICore {
        public event Action<OutputClass> FrameDecodeComplete;
        void someFunction() {
            SubOutputClass myOutput = new SubOutputClass(1,2);
            FrameDecodeComplete(myOutput);
        }
        private SubOutputClass : OutputClass
        {
            public SubOutputClass(int var1, int var2) : base(var1, var2)
            {
            }
        }
    }
