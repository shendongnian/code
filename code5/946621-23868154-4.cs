    public class MyFile 
    {
        // EXT2-401-B-140422-1540-1542.mp4
        public string part1 { get; set;}
        public string part2 { get; set;}
        public string part3 { get; set;}
        public string date { get; set;}
        public string part5 { get; set;}
        public string part6 { get; set;}
    
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
