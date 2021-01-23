            try
            {
                throw new FileLoadException("Custom error string");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
