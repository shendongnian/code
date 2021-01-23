    public static IEnumerable<AttachLabel> GetAttachLabel()
    {
        using (var db = new Entities())
        {
            return from item in db.tblAttachLabels
                    select new AttachLabel
                    {
                        ID = item.ID,
                        Text = item.Text
                    };
        }
    }
