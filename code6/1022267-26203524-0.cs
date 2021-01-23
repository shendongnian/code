    List<Box>[] MainArr = new List<Box>[1];
    MainArr[0] = new List<Box>();
    Box Box1 = new Box(1);
    MainArr[0].Add(Box1);
    
    var arr = Array.ConvertAll(MainArr, x => x.ToArray());
    
    System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(arr.GetType());
    System.IO.StreamWriter fileWrite = new System.IO.StreamWriter(@"C:\Users\Giorgos\Desktop\ConsoleApplication1\ArrListBox.xml");
    writer.Serialize(fileWrite, arr);
    fileWrite.Close();
