    namespace SEGY_TEST
    {
        class BinaryHeader
        {
            string fname;
            public int si;
            public int spt;
            public int fc;
            public string sfc;
            public int bytef; // byte format.
        public BinaryH(string fname)
        {
            this.fname = fname;
            this.lee();
            this.segyformat(this.fc);
            //Console.WriteLine("Abriendo {0}", this.fname);
        }
        
        public void segyformat(int fc)
        {
            switch (this.fc)
            {
                case 1:
                    this.bytef = 4;
                    this.sfc= "IBM-FLOAT";
                    break;
                case 3:
                    this.bytef = 2;
                    this.sfc = "INT-16";
                    break;
                case 5:
                    this.bytef = 4;
                    this.sfc = "IEEE-FLOAT";
                    break;
                case 8:
                    this.bytef = 1;
                    this.sfc = "INT-8";
                    break;
                default:
                    while (true) 
                    {
                        Console.WriteLine("{0} -- FORMAT NOT SUPPORTED PLEASE EXIT",this.fc);
                        Console.Read();
                    } 
                    
                    
            }
        }
        public void lee()
        {
            byte[] datos=new byte[400];
            using (FileStream readFile = new FileStream(this.fname,
                FileMode.Open, FileAccess.Read))
            {
                readFile.Seek(3200, SeekOrigin.Begin);
                readFile.Read(datos, 0, 400);
                readFile.Close();
            }
            this.si = Endiann.BE16ToInt16(datos, 16); // sample interval
            this.spt = Endiann.BE16ToInt16(datos, 20); // samples per trace
            this.fc = Endiann.BE16ToInt16(datos, 24); // format code
            //Console.WriteLine("{0} sample interval",si);
            //Console.WriteLine("{0} sample per trace", spt);
            //Console.WriteLine("{0} Fomrmat code", fc);
        }
    }
    }
        public static int BE16ToInt16(byte[] buf, int i)
        {
            return (Int16)((buf[i] << 8) | buf[i + 1]);
        }
