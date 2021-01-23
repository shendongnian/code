            private int ID;
            private string Make;
            private string Model;
            private int MBSize;
            private double Price;
            private int vr;
            public int id
            {
                get { return this.ID; }
                set { this.ID = value; }
            }
            public string make
            {
                get { return this.Make; }
                set { this.Make = value; }
            }
            public string model
            {
                get { return this.Model; }
                set { this.Model = value; }
            }
            public int mbsize
            {
                get { return this.MBSize; }
                set { this.MBSize = value; }
            }
            public double price
            {
                get { return this.Price; }
                set { this.Price = value; }
            }
            public int VR
            {
                get { return this.vr; }
                set { this.vr = value; }
            }
        }
        private static ArrayList  mps;
        public static void mp3()
        {
            mp3players mp1 = new mp3players();
            mp1.id = 1;
            mp1.make = "GET technologies .inc";
            mp1.model = "HF 410 ";
            mp1.mbsize = 4096;
            mp1.price = 129.95;
            mp1.VR = 500;
            mp3players mp2 = new mp3players();
            mp2.id = 2;
            mp2.make = "Far & Loud";
            mp2.model = "XM 600 ";
            mp2.mbsize = 8192;
            mp2.price = 224.95;
            mp2.VR = 500;
            mp3players mp3 = new mp3players();
            mp3.id = 3;
            mp3.make = "Innotivative";
            mp3.model = "Z3 ";
            mp3.mbsize = 512;
            mp3.price = 79.95;
            mp3.VR = 500;
            mp3players mp4 = new mp3players();
            mp4.id = 4;
            mp4.make = "Resistance S.A.";
            mp4.model = "3001 ";
            mp4.mbsize = 4096;
            mp4.price = 124.95;
            mp4.VR = 500;
            mp3players mp5 = new mp3players();
            mp5.id = 5;
            mp5.make = "CBA";
            mp5.model = "NXT volume ";
            mp5.mbsize = 2048;
            mp5.price = 159.05;
            mp5.VR = 500;
            mps = new ArrayList();
            mps.Add(mp1);
            mps.Add(mp2);
            mps.Add(mp3);
            mps.Add(mp4);
            mps.Add(mp5);
            foreach (mp3players value in mps)
            {
                Console.WriteLine("ID: " + value.id);
                Console.WriteLine("Make: " + value.make);
                Console.WriteLine("Model: " + value.model);
                Console.WriteLine("MBSize: " + value.mbsize);
                Console.WriteLine("Price: " + value.price);
                Console.WriteLine();
            }
        }
        public static void ammount()
        {
            foreach (mp3players value in mps)
            {
                Console.WriteLine("ID: " + value.id);
                Console.WriteLine("Model: " + value.model);
                Console.WriteLine();
            }
        }
