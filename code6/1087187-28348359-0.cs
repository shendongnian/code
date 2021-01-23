                bool mContinue = true;
                int mReconnectCount = 0;
                while ((mContinue) && (!(reader.EOF)))
                {
                    if (Response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        try
                        {
                            ExtractDataFromStream(reader);
                        }
                        catch (Exception ex)
                        {
                            mContinue = false;
                            //Because we are on a separate thread, we can't update
                            //the UI directly.  So we save the error message to a
                            //global variable (string.)
                            string strErrorMessage = "Exception: " + ex.Message + "\n\nStackTrace: " + ex.StackTrace;
                            Console.WriteLine(strErrorMessage);
                        }
                    }
                    else
                    {
                        //To prevent infinite stuck loops, i.e. website goes down
                        //try a counter
                        if (mReconnectCount <= 1000)
                        {
                            TryToReconnect();
                            mReconnectCount++;
                        }
                        else
                        {
                            mContinue = false;
                            mReconnectCount = 0;
                        }
                    }
                    //ProgressChanged Event can be used for reading data, saving data, etc.
                    BW.ReportProgress(0);
                }
