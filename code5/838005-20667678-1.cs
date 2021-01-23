            ... ... ...
            int id = 0;
            var hdnId  = item.FindControl("hdnId") as HiddenField;
            CheckBox ck = (CheckBox)item.FindControl("checkNote");
            //I would check null for ck
            if (ck != null && ck.Checked && hdnId != null && int.TryParse(hdnId.Value, out id)
            {                    
                    // db is the datacontext
                    Note note = db.Notes.Single( c => c.Id== id );
                    db.Notes.DeleteOnSubmit(note );
                    db.SubmitChanges();
            }
