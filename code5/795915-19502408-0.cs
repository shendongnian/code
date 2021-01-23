     static decimal evaluate(string expression)
            {
                var loDataTable = new DataTable();
                return (decimal)(loDataTable.Compute(expression, ""));
            }
