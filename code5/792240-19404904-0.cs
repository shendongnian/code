    Dictionary<int, List<string>> idFilenames = fileList
        .Select(fn => {
            string fnwoe = Path.GetFileNameWithoutExtension(fn);
            int underscoreIndex = fnwoe.IndexOf('_');
            int ID = -1;
            if(underscoreIndex >= 0)
            {
                string idPart = fnwoe.Substring(0, underscoreIndex);
                int.TryParse(idPart, out ID);
            }
            return new { FileName = fn, ID };
        })
        .GroupBy(x => x.ID)
        .ToDictionary(g => g.Key, g => g.Select(x => x.FileName).ToList());
