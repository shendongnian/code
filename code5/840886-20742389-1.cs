    using(FileStream fs=new FileStream(path,FileMode.OpenOrCreate))
    using (StreamWriter str=new StreamWriter(fs))
    {
       str.BaseStream.Seek(0,SeekOrigin.End); 
       str.Write("mytext.txt.........................");
       str.WriteLine(DateTime.Now.ToLongTimeString()+" "+DateTime.Now.ToLongDateString());
       string addtext="this line is added"+Environment.NewLine;
            
       str.Flush();
    }
    File.AppendAllText(path,addtext);  //Exception occurrs ??????????
    string readtext=File.ReadAllText(path);
    Console.WriteLine(readtext);
