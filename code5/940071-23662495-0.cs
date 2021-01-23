    /* ... */
    var contentDisposition = new System.Net.Mime.ContentDisposition("attachment")
    {
        FileName = FinalName + ".mp4"
    }:
    // Properly encode header using ContentDisposition class.
    Response.AddHeader("Content-Disposition", contentDisposition.ToString());
