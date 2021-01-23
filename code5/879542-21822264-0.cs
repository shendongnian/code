    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    int counter =0 ;
     while((line = file.ReadLine()) != null)
     {
        var lineData= line.Split(',');
        GlobalDataClass.Array[counter,0] =  double.Parse(lineData[0]);
        GlobalDataClass.Array[counter,1] =  double.Parse(lineData[1]);
        counter++;
    }
