    catch (WebException ex)
                {
                    var hwr = (HttpWebResponse)ex.Response;
                    if (hwr != null)
                    {
                        var responseex = hwr.StatusCode;
                        int statcode = (int)responseex;
                        if (statcode == 404)
                        {
                            Utility.Instance.log(logPath, "The file might not be availble yet at the moment. Please try again later or contact your system administrator.", true);
                        }
                        if (statcode == 401)
                        {
                            Utility.Instance.log(logPath, "Username and Password do not match.", true);
                        }
                        if (statcode == 408)
                        {
                            Utility.Instance.log(logPath, "The operation has timed out", true);
                        }
                    }
                    else
                    {
                        Utility.Instance.log(logPath, ex + ". Please contact your administrator.", true);//Or you can do a different thing here
                    }
                }
