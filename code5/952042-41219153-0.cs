    /// <summary>
    /// To demonstrate extraction of file extension from base64 string.
    /// </summary>
    /// <param name="base64String">base64 string.</param>
    /// <returns>Henceforth file extension from string.</returns>
    public static string GetFileExtension(string base64String)
    {
    var data = base64String.Substring(0, 5);
    switch (data.ToUpper())
     {
         case "IVBOR":
            return "png";
         case "/9J/4":
             return "jpg";
         case "AAAAF":
             return "mp4";
         case "JVBER":
             return "pdf";
         case "AAABA":
             return "ico";
         case "UMFYI":
             return "rar";
         case "E1XYD":
             return "rtf";
         case "U1PKC":
            return "txt";
         case "MQOWM":
         case "77U/M":
            return "srt";
         default:
            return string.Empty;
     }
    }
