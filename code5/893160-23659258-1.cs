protected void writeJsonData (string s) {
    HttpContext context=this.Context;
    HttpResponse response=context.Response;
    context.Response.ContentType = &quot;text/json&quot;;
    byte[] b = response.ContentEncoding.GetBytes(s);
    <b>response.AddHeader(&quot;Content-Length&quot;, b.Length.ToString());</b>
    response.BinaryWrite(b);
    try
    {
        this.Context.Response.Flush();
        this.Context.Response.Close();
    }
    catch (Exception) { }
}
