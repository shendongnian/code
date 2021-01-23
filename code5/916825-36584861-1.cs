    ...
    MemoryStream ms = new MemoryStream();
    using(MemoryStream tempStream = new MemoryStream)
    {
        workbook.Write(tempStream);
        var byteArray = tempStream.ToArray();
        ms.Write(byteArray, 0, byteArray.Length);
        HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
        result.Content = new StreamContent(ms);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
        result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
        result.Content.Headers.ContentDisposition.FileName = string.Format("{0}.xlsx", dt.TableName);
        return result;
    }
