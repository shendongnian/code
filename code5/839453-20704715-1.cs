    foreach (string str in Directory.GetFiles(MapPath("~/_Files/Upload/" + User.Identity.Name + "/"), "RS_*.*"))
    {
       using(MemoryStream ms = new MemoryStream())
       using(Image img = System.Drawing.Image.FromFile(str))
       {
          img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
          cmd.Parameters.Clear();
          cmd.CommandText = "INSERT INTO ReportingServiceImages VALUES (@ReportingServiceID, @img)";
          cmd.Parameters.AddWithValue("@ReportingServiceID", ID);
          cmd.Parameters.AddWithValue("@img", ms.GetBuffer());
          cmd.ExecuteNonQuery();
          cmd.Dispose();
       }
       File.Delete(str);
    }
