        ILookup<string, TableColumns> sourceColumnLookup = sourceLlist
                .ToLookup(t => t.Column.Substring(1));
        //...
        private void FindLinkingTables(
            ILookup<string, TableColumns> sourceLookup, 
            ILookup<string, TableColumns> sourceColumnLookup,
            TableSearchNode parentNode, string targetTable, int maxSearchDepth)
        {
            if (parentNode.Level >= maxSearchDepth) return;
            var tableColumns = sourceLookup[parentNode.Table].Select(x => x.Column);
            foreach (string sourceColumn in tableColumns)
            {
                string shortName = sourceColumn.Substring(1);
                var tables = sourceColumnLookup[shortName]
                    .Where(tableColumn => !tableColumn.Table.Equals(parentNode.Table)
                                          && !parentNode.AncenstoryReversed.Contains(tableColumn.Table))
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
                        FindLinkingTables(sourceLookup, sourceColumnLookup, table, targetTable, maxSearchDepth);
                    }
                    else
                    {
                        table.NotifySeachResult(true);
                    }
                }
            }
        }
