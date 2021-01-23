            catch (OperationCanceledException ex)
            {
                try
                {
                    if (putStream != null)
                        putStream.Dispose();
                }
                catch (WebException) { }
                return false;
            }
            finally{
                fs.Close();
            }
