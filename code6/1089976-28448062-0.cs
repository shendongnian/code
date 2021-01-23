        [TestMethod]
        public void TestMethod1()
        {
            // Original code with correct constant type.
            MyFunction(new List<float> { 3.0f, 4.0f });
            
            // Using an overload with a params array argument.
            MyFunction(3.0f, 4.0f);
            // Various float constant flavours.
            MyFunction(3f, 3.0f, .0f, 3e-10f, (float)3);
            // Implicit cast to float from anything with lesser precision or an explicit cast to float.
            MyFunction((byte)1, (short)1, (int)1, 1, (long)1, 1L, (float)1);
        }
        
        void MyFunction(List<float> list)
        {
            throw new NotImplementedException();
        }
        void MyFunction(params float[] args)
        {
            throw new NotImplementedException();
        }
