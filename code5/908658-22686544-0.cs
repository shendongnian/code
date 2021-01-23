     using (Galway__Entities db = new Galway__Entities())
        {
          DateTime RemovableDate = new DateTime();
          List<PROJ_ACCS_StockControl_DeletedPLURecord> DeletedPLURecords = db.PROJ_ACCS_StockControl_DeletedPLURecord.Where(x => x.TimeStamp <= RemovableDate).ToList();
        
          foreach (var item in DeletedPLURecords)
          {
              var e = db.PROJ_ACCS_StockControl_DeletedPLURecord.Find(item.Id);
              if (e != null)
              {
                   Db.PROJ_ACCS_StockControl_DeletedPLURecord.Remove(e);
              }
          }
          db.SaveChanges();
        }
