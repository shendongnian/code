      HttpFileCollection hfc = Request.Files;
      for (int i = 0; i < hfc.Count; i++)
            {
                HttpPostedFile hpf = hfc[i];
                if (hpf.ContentLength > 0)
                {
                   hpf.SaveAs(Server.MapPath("Your Path"));
                }
                }
