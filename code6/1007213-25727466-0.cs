            private static bool TryOpenFile()
            {
                try
                {
                    // Attempt to open file.
                    return true;
                }
                catch (IOException exception)
                {
                    // Log the error.
                    // Unable to open file... do something for the user.
                    return false;
                }
                catch (Exception)
                {
                    // Log.
                    throw;
                }
                finally
                {
                    // Can do things here that should always happen regardless.
                }
            }
