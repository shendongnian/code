    internal class MyClass
    {
        public void Do()
        {
            Exception exception = null;
            try
            {
                //perform a measurement on the DUT
                signalSource.SetOutput(on);
                DUT.RunMeasurement();
            }
            catch (Exception e)
            {
                exception = e;
                throw;
            }
            finally
            {
                try
                {
                    //both devices have to be set to a valid state at end of the procedure, independent of if any exception occurred
                    signalSource.SetOutput(off);
                    DUT.Reset();
                }
                catch (Exception e)
                {
                    if (exception != null)
                        throw new AggregateException(exception, e);
                    throw;
                }
            }
        }
    }
