    public static IEnumerable<AttachLabel> GetAttachLabel()
    {
        using (var db = new Entities())
        {
            return db.tblAttachLabels.Select(item => new AttachLabel
            {
                ID = item.ID,
                Text = item.Text
            });
        }
    }
