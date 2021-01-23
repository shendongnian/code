        foreach (string sourceColumn in tableColumns)
        {
            string shortName = sourceColumn.Substring(1);
            IEnumerable<TableSearchNode> tables =
                sourceList.Where(x => x.Column[0].Equals(shortName) &&
                                      x.Color == White)
                          .Select(x => new TableSearchNode
                                           {
                                                Table = x.Table,
                                                Column = x.Column,
                                                Level = parentNode.Level + 1
                                            });
            foreach (TableSearchNode table in tables)
            {
                parentNode.AddChildNode(sourceColumn, table);
                table.Color = Grey;
   
                if (!table.Table.Equals(targetTable))
                {
                    FindLinkingTables(sourceList, table, targetTable, maxSearchDepth);
                }
                else
                {
                    table.NotifySeachResult(true);
                }
                table.Color = Black;
            }
        }
