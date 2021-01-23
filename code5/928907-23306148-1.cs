    // Assume there is some list of LockTime objects.
    List<LockTime> listOfTimes = new List<LockTime>
    {
        new LockTime(1, 5),
        new LockTime(10, 15)
    };
    // Serialize this list into a JSON string.
    string serializedList = JsonConvert.SerializeObject(listOfTimes, Formatting.Indented);
    // You can write this out to a file like this:
    //File.WriteAllText("path/to/json/file", serializedList);
    // You can then read it back in, like this:
    //var serializedList = File.ReadAllText("path/to/json/file")
    // To get a list of integers, you can do:
    List<LockTime> deserializedList = (List<LockTime>)JsonConvert.DeserializeObject(serializedList, typeof(List<LockTime>));
    // Grab whatever data you want from this list to store somewhere, such as a list of all Start integers.
    List<int> intList = deserializedList.Select(entry => entry.Start).ToList();
