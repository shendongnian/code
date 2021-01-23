    try
    {
        private void TestFunc(int a)
        {
            switch(a)
            {
                case(0):
                {
                    Console.WriteLine("Zero");
                    throw new NotImplementedException();
                }
            }
        }
    }
    catch (NotImplementedException e)
    {
        //Just do nothing here
    }
