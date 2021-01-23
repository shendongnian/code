    class test
    {
        int currentIndex = 0;
        private string myMethod(string input)
        {
            string val = input.Substring(currentIndex, 15);
            currentIndex+=15;
            return val;
        }
    }
