        private void FindLinkingTables(List<TableColumns> sourceList, TableSearchNode root, string targetTable, int maxSearchDepth)
        {
            Stack<TableSearchNode> stack = new Stack<TableSearchNode>();
            TableSearchNode current;
            stack.Push(root);
            while (stack.Count > 0 && stack.Count < maxSearchDepth)
            {
                current = stack.Pop();
                var tableColumns = sourceList.Where(x => x.Table.Equals(current.Table))
                                             .Select(x => x.Column);
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
                                                        Level = current.Level + 1
                                                    });
                    foreach (TableSearchNode table in tables)
                    {
                        current.AddChildNode(sourceColumn, table);
    
                        if (!table.Table.Equals(targetTable))
                        {
                            table.Color = Grey;
                            stack.Push(table);
                        }
                        else
                        {
                            // you could go ahead and construct the ancestry list here using the stack
                            table.NotifySeachResult(true);
                            return;
                        }
                    }
                }
                current.Color = Black;
            }
        }
