     public bool CheckTagName(string tagname) {
                var tagtable = (from u in db.TagTables
                                where u.TagName.Contains(tagname)
                                select u).FirstOrDefault();
                if (tagtable != null) {
                    return true;
                }
                else {
                    return false;
                }
            }
