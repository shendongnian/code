    private void BindDataInGrid(string[] argFilePaths)
    {
        List<Parent> recordsList = new List<Parent>();
            for (int i = 0; i < argFilePaths.Length; i++)
            {
               recordsList.AddRange
                   (
                         XDocument.Load(argFilePaths[i]).Root.Descendants("Resident")
                         .Select(data => new Parent()
                         {
                             Child1 = data.Element("Child1").Value,
                             Child2 = data.Element("Child2").Value,
                         }).ToList()
                    );
            }
    }
