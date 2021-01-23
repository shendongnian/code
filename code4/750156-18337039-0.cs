        int add(int a, int b)
        {
            int returnValue = 0;
            try
            {
                returnValue = checked(a + b);
            }
            catch(System.OverflowException ex)
            {
                //TODO: Do something with exception or rethrow
            }
            return returnValue;
        }
        void test()
        {
            int max = int.MaxValue;
            int with_call = add(max, 1);
        }
