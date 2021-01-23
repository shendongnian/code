    private string id;
    private string name;
    private string age;
    private string training;
    while((line = file.ReadLine()) != null)
    {
        id = line.Substring(0, 3)
        name = line.Substring(3, 10)
        age = line.Substring(12, 2)
        training = line.Substring(14, 10)
        ...
        if (string.IsNullOrWhiteSpace(name))
        {
            // ignore this line if the name is blank
        }
        else
        {
            // do something useful
        }
        counter++;
    }
