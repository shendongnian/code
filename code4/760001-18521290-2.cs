    public class CustomMetaTable : MetaTable
    {
        private MetaTable table;
        private MetaModel model;
        public CustomMetaTable(MetaTable table, MetaModel model)
        {
            this.table = table;
            this.model = model;
            var tableNameField = this.table.GetType().FindMembers(MemberTypes.Field, BindingFlags.NonPublic | BindingFlags.Instance, (member, criteria) => member.Name == "tableName", null).OfType<FieldInfo>().FirstOrDefault();
            if (tableNameField != null)
                tableNameField.SetValue(this.table, TableName);
        }
        public override System.Reflection.MethodInfo DeleteMethod
        {
            get { return table.DeleteMethod; }
        }
        public override System.Reflection.MethodInfo InsertMethod
        {
            get { return table.InsertMethod; }
        }
        public override System.Reflection.MethodInfo UpdateMethod
        {
            get { return table.UpdateMethod; }
        }
        public override MetaModel Model
        {
            get { return model; }
        }
        public override string TableName
        {
            get
            {
                return table.TableName
                            .Replace("CRPDTA", ConfigurationManager.AppSettings["BusinessDataSchema"])
                            .Replace("CRPCTL", ConfigurationManager.AppSettings["ControlDataSchema"]);
            }
        }
        public override MetaType RowType
        {
            get { return table.RowType; }
        }
    }
