    public virtual ICollection<Attachment> Attachments
    {
        // defines get_Attachments
        get
        {
                        // calls get_Attachments
            return this.Attachments.Where(x => x.del != true) as ICollection<Attachment>;
        }
