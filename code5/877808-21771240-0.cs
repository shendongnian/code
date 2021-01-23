    var allValues = ImageArray.OfType<float>();
    string[] lines = new string[240];
    for(int i=0; i<240; i++)
    {
       lines[i] = string.Join(",", allValues.Skip(i*320).Take(320));
    }
 
     File.AppendAllLines(@"C:\Users\mtech\Desktop\sathya.txt", lines);
     
