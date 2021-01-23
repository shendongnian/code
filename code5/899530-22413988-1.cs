    protected void EntryList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var dataItem = e.Row.DataItem as EntryItem;
            if (dataItem == null)
                return;
            var imageControl = e.Row.FindControl("EntryImage") as global::Sitecore.Web.UI.WebControls.Image;
            var introduction = e.Row.FindControl("IntroductionLiteral") as Literal;
            if (imageControl == null || introduction == null)
                return;
            imageControl.MaxWidth = m_imageMaxSize.Width;
            imageControl.MaxHeight = m_imageMaxSize.Height;
            if (dataItem.ThumbnailImage.MediaItem == null)
                imageControl.Field = "Image";
            if (!string.Empty(data["introduction"]))
                introduction.Text = string.Format("<p>{0}</p>", data["introduction"]);
        }
