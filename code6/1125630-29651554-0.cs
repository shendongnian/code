    // Include IO, Linq namespace
    using System.IO;
    using System.Linq;
    
    // To search files in a directory and collect in a collection
    var directoryPath = "";
    var fileNameList = Directory.GetFiles(directoryPath,"*.*", SearchOption.AllDirectories).ToList().Select(e=>Path.GetFileName(e));
    
    // Casting the List to Array using ToArray()
    var fileNameArray = fileNameList.ToArray();
