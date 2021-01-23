    public static IEnumerable<AttachLabel> GetAttachLabel()
    {
        Entities db = new Entities();
        var items = from al in db.tblAttachLabels select al;
        return items.Select(new AttachLabel()
        {
           ID = item.ID,
           Text = item.Text
        });
    }
