    DataTable[] splittedtables = tbl.AsEnumerable()
        .Select((row, index) => new { row, index })
        .GroupBy(x => x.index / 12)  // integer division, the fractional part is truncated
        .Select(g => g.Select(x => x.row).CopyToDataTable())
        .ToArray();
