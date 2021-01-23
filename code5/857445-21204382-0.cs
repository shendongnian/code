    catch (Exception ex)
                {
                    WebException webexception = (WebException)ex;
                    var responseresult = webexception.Response as HttpWebResponse;
    
                    //Code to debug Http Response
                    var responseStream = webexception.Response.GetResponseStream();
                    string fault_message = string.Empty;
                    int lastNum = 0;
                    do
                    {
                        lastNum = responseStream.ReadByte();
                        fault_message += (char)lastNum;
                    } while (lastNum != -1);
                    responseStream.Close();
    }
