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
