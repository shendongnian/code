    bool result = false;
        using (WebClient client = new WebClient())
        {
            try
            {
                Stream stream = client.OpenRead(url);
                if (stream != null)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }
            catch
            {
                //Any exception will returns false.
                result = false;
            }
        }
        return result;
