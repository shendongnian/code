        private void FindLinkingTables(ILookup<string, TableColumns> sourceLookup, TableSearchNode parentNode, string targetTable, int maxSearchDepth)
        {
            if (parentNode.Level < maxSearchDepth)
            {
                var tableColumns = sourceLookup[parentNode.Table].Select(x => x.Column);
                foreach (string sourceColumn in tableColumns)
                {
                    string shortName = sourceColumn.Substring(1);
                    var tables = sourceLookup
                        .Where(
                            group => !group.Key.Equals(parentNode.Table)
                                     && !parentNode.Ancenstory.Contains(group.Key))
                        .SelectMany(group => group)
                        .Where(tableColumn => tableColumn.Column.Substring(1).Equals(shortName))
                        .Select(
                            x => new TableSearchNode
                            {
                                Table = x.Table,
                                Column = x.Column,
                                Level = parentNode.Level + 1
                            });
                    foreach (TableSearchNode table in tables)
                    {
                        parentNode.AddChildNode(sourceColumn, table);
                        if (!table.Table.Equals(targetTable))
                        {
                            FindLinkingTables(sourceLookup, table, targetTable, maxSearchDepth);
                        }
                        else
                        {
                            table.NotifySeachResult(true);
                        }
                    }
                }
            }
        }
