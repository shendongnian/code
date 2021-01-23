    string list = "List.csv";
    string listDelete = "ListToDelete.csv";
    string newList = "newList.txt";
    var array1 = File.ReadAllLines(list);
    var array2 = File.ReadAllLines(listDelete);
                      
    var noduplicates = Array.FindAll(array1, line => !Array.Exists(array2, line2 => line.StartsWith(line2)));
    //Writes all the non duplicates to a different file
    File.WriteAllLines(newList, noduplicates);
