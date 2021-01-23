    public void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            IEnumerable<Uri> uris = GetUris();
            List<Tuple<Uri, Uri>> pairs = new List<Tuple<Uri, Uri>>();
            for  (int i = 0; i < uris.Count; i += 2)
            {
                var uri1 = uris[i];
                var uri2 = i + 1 < uris.Count ? uris[i + 1] : null;
                pairs.Add(new Tuple<Uri, Uri>(uri1, uri2));
            }
            rpt.DataSource = pairs;
            rpt.DataBind();
        }
    }
