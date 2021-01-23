            var list = new List<string>();
            for (int i = 1; i <= 7; i++)
            {
                list.Add((oRngListRow.Cells[1, i].Value2 ?? string.Empty).ToString());
            }
