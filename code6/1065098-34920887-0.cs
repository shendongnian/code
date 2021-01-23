        using (Database database = new Database(@"msi_path", DatabaseOpenMode.Transact))
            {
                using (var view = database.OpenView(database.Tables["Media"].SqlSelectString))
                {
                    view.Execute();
                    Record record = view.Fetch();
                    while (record != null)
                    {
                        if (record.GetString(4) != "") // replace the empty string with ur value
                        {
                            record.SetString("Cabinet", "#" + record.GetString(4));
                            view.Modify(ViewModifyMode.Assign, record);
                            database.Commit();
                        }
                        record = view.Fetch();
                    }
}
