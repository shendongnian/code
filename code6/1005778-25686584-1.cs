        public override void Delete(int id)
        {
            var files = SqlQuery(@"SELECT * FROM dbo.PropertyFiles WHERE 
                IsDeleted = 1 AND DATEADD(MINUTE, 30, DeletedAt) < GETUTCDATE()");
            foreach (PropertyFile file in files)
            {
                try
                {
                    File.Delete(file.FilePath);
                }
                catch (Exception ex)
                {
                    //TODO log the errors encountered when attempting to delete
                }
            }
            base.Delete(id);
        }
