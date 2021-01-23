    <asp:Literal ID="ltrImage" runat="server">
    DataTable dt = new DataTable();
    DAL.DAL_UploadImgVideo obj = new DAL_UploadImgVideo();
    dt = obj.ImgVideoFetchDetails(ID);
    if (dt.Rows.Count > 0)
    {
        var imgFormat = "<image src='JO_Images/UpdImgVideo/{0}' />";
        var imgStr = new StringBuilder();
        for (int i = 2; i < dt.Columns.Count - 3; i++)
        {
            string Cname = dt.Columns[i].ToString();
            string FImg = dt.Rows[0][Cname].ToString();
            imgStr.Append(string.Format(imgFormat, Fimg));
        }
        var ltrImg = ((Literal)e.Item.FindControl("ltrImage"));
        ltrImg.Text = imgStr.ToString();
    }
