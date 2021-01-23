                var connection = new Connection();
            try
            {
                connection.DoSomething();
            }
            finally
            {
                // Check for a null resource.
                if (connection != null)
                {
                    ((IDisposable)connection).Dispose();
                }
            }
