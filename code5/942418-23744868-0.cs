                if (newClubPrimaryKeyId > 0)
                {
                    string q = @"UPDATE NewClub SET LastActivityDate='" + DateTime.Now + "' WHERE Id="+newClubPrimaryKeyId;
                   
                    using (var context = new ReportingContext())
                    {
                         var result = context.Database.ExecuteSqlCommand(q);
                    }
                   
                }
