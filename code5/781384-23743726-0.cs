    [HttpPost]
    public string ValidateReCaptcha(string captchaChallenge, string captchaResponse)
    {
        if (captchaChallenge != null && captchaResponse != null)
        {
            // original code, remains unchanged
            /*
              ...snipped for clarity
            */
            // Clean up the streams (relocated to make it reachable code)
            reader.Close();
            dataStream.Close();
            response.Close();
            if (responseFromServer.ToString() != "true")
            {
                errorCodeList.Add(8);
                return responseFromServer + strPrivateKey; // "IF" ends execution here
            }
            return responseFromServer; // "ELSE" ends execution here
        }
        errorCodeList.Add(8);
        return null;
    }
