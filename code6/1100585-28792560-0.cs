     public void Main()
        {
            var dt = new DataTable();
            new OleDbDataAdapter().Fill(dt, this.Dts.Variables["User::Names"].Value);
            var list = dt.Rows.OfType<DataRow>().Select(i => i[0].ToString()).ToList();
            this.Dts.Variables["User::NameList"].Value = list;
            this.Dts.TaskResult = (int)ScriptResults.Success;
        }
 
