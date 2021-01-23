    System.Xml.XmlNodeList tempNodelist = Your stuff;
                    IDisposable disposeMe = tempNodelist as IDisposable;
                    if (disposeMe != null)
                    {
                       disposeMe.Dispose();
                    }
