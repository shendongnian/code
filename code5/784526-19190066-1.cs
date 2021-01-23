    public void Example()
    {
        List<CellInfo> _cells = new List<CellInfo>();
        _cells.Add(new CellInfo { Column = 6, Row = 3, Value = "Rak" });
        _cells.Add(new CellInfo { Column = 3, Row = 8, Value = "Rak" });
        _cells.Add(new CellInfo { Column = 2, Row = 4, Value = "Rak" });
        _cells.Add(new CellInfo { Column = 5, Row = 7, Value = "Sac" });
        _cells.Add(new CellInfo { Column = 1, Row = 3, Value = "Sac" });
---
        int[] rowsContainingRak = _cells.Where(cell => cell.Column == 0
                                            && cell.Value.Contains("Rak"))
                                                .OrderBy(cell => cell.Row)
                                                    .Select(cell => cell.Row)
                                                        .ToArray();
        string[] row0Values = _cells.Where(cell => cell.Row == 0)
                                    .OrderBy(cell => cell.Column)
                                        .Select(cell => cell.Value)
                                            .ToArray();
    }
