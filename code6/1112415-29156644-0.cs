    public List<double> readFileToList(string Path)
        {
    
            var cells = new List<double>();
            string path = label3.Text;
    
            if (File.Exists(path))
            {
                double temp = 0;
                cells.AddRange(File.ReadAllLines(path)
                    .Where(line => double.TryParse(line, out temp))
                    .Select(l => temp)
                    .ToList());
                int totalCount = cells.Count();
                cellsNo.Text = totalCount.ToString();
    
            }
    
           return cells;
    
        }
    
