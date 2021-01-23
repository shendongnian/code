        try
        {
            //some cool stuff with webClient
        }
        catch (WebException ex)
        {
            using (var stream = ex.Response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var s = reader.ReadToEnd();
                throw new Exception(s, ex);
            }
        }
        catch (Exception e)
        {
            throw e;
        }
