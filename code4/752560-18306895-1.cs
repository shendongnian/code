        string albumName = Context.Request.QueryString["Album"];
        try
        {
            DirectoryInfo dir = new DirectoryInfo(MapPath(string.Format("Images/{0}", albumName)));
            
            var dataToBeBound = dir.GetFiles().Select(x => new
            {
                Name = x.Name,
                Image = string.Format("~/Images/{0}/{1}", albumName, x.Name)
            }).ToList();
            dtlist.DataSource = dataToBeBound;
            dtList.DataBind();
        }
        catch (Exception ex)
        {
            throw;
        }
