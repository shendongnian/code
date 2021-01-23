    var result = db.Issues
          .GroupJoin
          (
              db.IssueAttachments ,
              x=>x.IssueID ,
              x=>x.IssueID ,
              (i,ia)=>new
              {
                  i.IssueID,
                  /*** more fields ***/
                  NumberOfAttachments = ia.Count()
              }
          );
