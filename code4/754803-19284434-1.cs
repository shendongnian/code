        public DataSet GetDoucmentHistory(string siteUrl, string listName, int id)
        {
            using (ClientContext ctx = new ClientContext(siteUrl))            {
                ctx.Credentials = new NetworkCredential(_username, _password, _domain);
                var file = ctx.Web.Lists.GetByTitle(listName).GetItemById(id).File;
                var versions = file.Versions;
                ctx.Load(file);
                ctx.Load(versions);
                ctx.Load(versions, vs=>vs.Include(v=>v.CreatedBy));
                ctx.ExecuteQuery();
                
                var ds = CreatHistoryDataSet();
                foreach (FileVersion fileVersion in versions)
                {
                    var row = ds.Tables[0].NewRow();
                    row["CreatedBy"] = fileVersion.CreatedBy.Title;
                    row["Comments"] = fileVersion.CheckInComment;
                    row["Created"] = fileVersion.Created.ToShortDateString() + " " +
                                     fileVersion.Created.ToShortTimeString();
                    row["Title"] = file.Title;
                    row["VersionLabel"] = fileVersion.VersionLabel;
                    row["IsCurrentVersion"] = fileVersion.IsCurrentVersion;
                    ds.Tables[0].Rows.Add(row);
                }
                return ds;
            }
        }
        private static DataSet CreatHistoryDataSet()
        {
            DataSet ds = new DataSet();
            DataTable table = new DataTable();
            table.Columns.Add("Title");
            table.Columns.Add("Created");
            table.Columns.Add("CreatedBy");
            table.Columns.Add("EncodedAbsUrl");
            table.Columns.Add("VersionLabel");
            table.Columns.Add("Comments");
            table.Columns.Add("IsCurrentVersion");
            ds.Tables.Add(table);
            return ds;
        }
        
