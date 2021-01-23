    public class MyFile 
    {
        // EXT2-401-B-140422-1540-1542.mp4
        string part1;
        string part2;
        string part3;
        string date;
        string part5;
        string part6;
    
        void MyFile(string fileName)
        {
            string[] parts = fileName.split('-');
    
            part1 = parts[0];
            part2 = parts[1];
            part3 = parts[2];
            date  = parts[3];
            part5 = parts[4];
            part6 = parts[5];
        }
    }
