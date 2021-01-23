    class TreeDataTable : DataTable
    {
        public TreeDataTable()
            : this("trees")
        {
        }
        public TreeDataTable(string tableName)
            : base(tableName)
        {
            Columns.Add("Id");
            Columns.Add("Name");
            Columns.Add("ParentId");
            Columns.Add("Type");
        }
        public void AddFile(int id, string name, int parent)
        {
            AddRow(id, name, parent, typeof(FileInfo));
        }
        public void AddTree(Tree tree)
        {
            AddRow(tree.Id, tree.Name, tree.ParentId, typeof(DirectoryInfo));
            var table = tree.ToDataTable();
            foreach (var r in table.Rows.Cast<DataRow>())
                AddRow(Convert.ToInt32(r["Id"]), r["Name"].ToString(), Convert.ToInt32(r["ParentId"]), Type.GetType(r["Type"].ToString()));
        }
        public string ToXml()
        {
            using (var sw = new StringWriter())
            {
                using (var tw = new XmlTextWriter(sw))
                {
                    tw.Formatting = Formatting.Indented;
                    tw.WriteStartDocument();
                    tw.WriteStartElement(TableName);
                    ((IXmlSerializable)this).WriteXml(tw);
                    tw.WriteEndElement();
                    tw.WriteEndDocument();
                }
                return sw.ToString();
            }
        }
        private void AddRow(int id, string name, int parent, Type type)
        {
            var row = NewRow();
            row["Id"] = id;
            row["Name"] = name;
            row["ParentId"] = parent;
            row["Type"] = type.ToString();
            Rows.Add(row);
        }
    }
