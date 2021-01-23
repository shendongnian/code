    public void SaveTag(string tagname) 
    {
        if(!CheckTagName(tagname))
        {
            TagTable tag = new TagTable();
            tag.TagName = tagname;
            db.TagTables.InsertOnSubmit(tag);
            db.SubmitChanges();
        }
    }
    public bool CheckTagName(string tagname) 
    {
        var tagtable = (from u in db.TagTables
                        where u.TagName.Contains(tagname)
                        select u);
        return tagtable == null;
    }
