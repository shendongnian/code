        while (!isExcelInteractive())
        {
            Console.WriteLine("Excel is busy");
            await Task.Delay(25);
        }
