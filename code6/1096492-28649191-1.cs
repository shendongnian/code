            var cRows = new Dictionary<string, DataRow>(StringComparer.InvariantCultureIgnoreCase);
            foreach (DataRow oRow in oTable.Rows)
            {
                var sKey = oRow["KeyValue"].ToString();
                if (!cRows.ContainsKey(sKey))
                {
                    cRows.Add(sKey, oRow);
                }
                else
                {
                    cRows[sKey] = oRow;
                }
            }
