     class CustomException : Exception
    {
        public string errorMessage;
        public CustomException(string message)
        {
           errorMessage = message;
        }
        public void TestThrow(string ex)
        {
            MessageBox.Show(ex);
        }
    }
