    List<List<int>> values = new List<List<int>>();
    List<int> innerValues = new List<int>();
    foreach (string item in File.ReadAllLines(@"../../Archivos/TextFileTotalEspecies.txt"))
    {
        if (item == "End Animal")
        {
            values.Add(innerValues);
            innerValues = new List<int>();
            continue;
        }
        else if (item == "End")
        {
            break;
        }
        else
        {
            innerValues.Add(int.Parse(item));
        }
    }
