        private string GetExceptionString(int iter)
        {
            try
            {
                return RecursiveFunction(iter);
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        private string RecursiveFunction(int iter)
        {
            if (iter > 1)
                return RecursiveFunction(iter - 1);
            throw new Exception("Actual Exception Occurs Here");
        }
