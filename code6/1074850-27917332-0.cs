     Response.Buffer = true;
     Response.Charset = "";
     Response.Cache.SetCacheability(HttpCacheability.NoCache);
     Response.ContentType = dt.Rows[0]["RowId"].ToString();
     Response.AddHeader("content-disposition", "attachment;filename="
     + dt.Rows[0]["FileName"].ToString());
      Response.BinaryWrite(Data);
       Response.Flush();
       Response.End();
