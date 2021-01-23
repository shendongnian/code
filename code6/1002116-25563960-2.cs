    var lines = File.ReadAllLines("file.txt");
    var batch = new List<String>();
    for (var line in lines) {
        if (line.Trim().StartsWith("GO")) { // allows '--' sql comments after the go
             executeBatch(batch); 
             batch.Clear();
             continue;
        }
        batch.Add(line);
    }
    executeBatch(batch);
