    Dictionary<int, List<string>> idFilenames = fileList
        .Select(fileName =>
        {
            string fnwoe = Path.GetFileNameWithoutExtension(fileName);
            string idPart = fnwoe.Split('_').First();
            int id;
            int.TryParse(idPart, out id);
            return new { fileName, id };
        })
        .GroupBy(x => x.id)
        .ToDictionary(g => g.Key, g => g.Select(x => x.fileName).ToList());
