            var chgset = db.GetChangeSet();
            if (chgset != null)
            {
                foreach (object objToInsert in chgset.Inserts)
                {
                   db.GetTable(objToInsert.GetType()).DeleteOnSubmit(objToInsert);
                }
                //Undo deletes
                foreach (object objToDelete in chgset.Deletes)
                {
                    db.GetTable(objToDelete.GetType()).InsertOnSubmit(objToDelete);
                }
                ///this._DB.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, chgset.Deletes);
                db.Refresh(System.Data.Linq.RefreshMode.OverwriteCurrentValues, chgset.Updates);
            }
        }
