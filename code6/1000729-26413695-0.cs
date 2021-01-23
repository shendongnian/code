            catch (Exception ex)
            {
                if (ex is SshConnectionException || ex is SocketException)
                {
                    _ifwInstance.Error(string.Format("Ignoring {0} during listing directory", ex.Message));
                }
                else
                {
                    Debugger.Log(0, null, ex.InnerException.ToString());
                    throw new Exception("Login to SFT FAILED", ex);
                }
            }
