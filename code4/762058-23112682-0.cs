        string uri = String.Format(UriFiles, fileId);
        string response = string.Empty;
        string body = "{\"shared_link\": {\"access\": \"open\"}}";
        byte[] postArray = Encoding.ASCII.GetBytes(body);
        try
        {
            using (var client = new WebClient())
            {
                client.Headers.Add("Authorization: Bearer " + token);
                client.Headers.Add("Content-Type", "application/json");
                response = client.UploadString(uri, "PUT", body);
            }
        }
        catch (Exception ex)
        {
            return null;
        }
        return response;
