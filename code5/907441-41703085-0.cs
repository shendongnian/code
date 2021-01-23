    private bool DeleteFile(string image1_Address="")
            {
                try {
                    if (image1_Address != null && image1_Address.Length > 0)
                    {
                        string fullPath = HostingEnvironment.MapPath("~" + image1_Address);
                        if (System.IO.File.Exists(fullPath))
                        {
                            System.IO.File.Delete(fullPath);
                            return true;
                        }
                    }
                }catch(Exception e)
                { }
                return false;
            }
