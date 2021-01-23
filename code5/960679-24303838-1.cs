    string[] lines=File.ReadAllLines("matrix.txt");
    //assuming your matrix is initialized with 0s
    foreach(string line in lines)
    {
        string[] elementsInLine=line.Split(' ');
        int z1=int.Parse(elementsInLine[0]);
        int c=int.Parse(elementsInLine[1]);
        int x=int.Parse(elementsInLine[2]);
        matrix[z1,c,x]=int.Parse(elementsInLine[3]);
    }
