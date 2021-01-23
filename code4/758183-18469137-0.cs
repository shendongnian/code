        foreach (ExcelCell cell in excelRow.AllocatedCells)
        {
            if (cell.Value != null)
                Console.Write("{0}({1})", cell.Value, cell.Value.GetType().Name);
            Console.Write("\t");
        }
