    if (reader.HasRows)
    {
        context.Response.Clear();
        context.Response.ContentType = "application/pdf";
        context.Response.TransmitFile(reader["pdfpath"].ToString()); //the path must be actual physical path of the file
        contest.Response.End();
    }
    else
    {
        context.Response.Clear();
        context.Response.ContentType = "text/plain";
        context.Response.Write("No file found");
        contest.Response.End();
    }
