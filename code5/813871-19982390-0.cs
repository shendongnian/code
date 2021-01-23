            try
            {
                var result = 8 / 0;
            }
            catch (DivideByZeroException ex)
            {
                // Here, a more specific exception is caught.
            }
            catch (Exception ex)
            {
               // Otherwise, you'll get the exception here.
            }
