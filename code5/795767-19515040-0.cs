    public FileResult Download()
    {
        string base64 = getBase64ZIP();
        byte[] byteArray = Convert.fromBase64String(base64);
        return File(byteArray, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
    }
