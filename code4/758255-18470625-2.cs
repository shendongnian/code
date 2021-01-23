    try
    {
        byte[] result = client.UploadData(url, data);
    }
    catch (WebException ex)
    {
        using (var response = ex.Response as HttpWebResponse)
        {
            if (response != null)
            {
                HttpStatusCode code = response.StatusCode;
                using (var stream = response.GetResponseStream())
                using (var reader = new StreamReader(stream))
                {
                    string errorContent = reader.ReadToEnd();
                }
            }
        }
    }
