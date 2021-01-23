    public static void Main() {
        SneakyDictionary dictionary = ...
        dictionary.AddItemToDictionary("one", 1);
        dictionary.AddItemToDictionary("two", 2);
        dictionary.AddItemToDictionary("three", 3);
        // Access items in dictionary using indexer:
        Console.WriteLine(dictionary["one"]);
    }
