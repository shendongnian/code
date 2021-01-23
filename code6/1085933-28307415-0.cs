        public static void serializeIt()
        { 
            MyObject obj = new MyObject();
            obj.n1 = 1;
            obj.n2 = 24;
            obj.str = "Some String";
            MyObject obj2 = new MyObject();
            obj2.n1 = 1;
            obj2.n2 = 24;
            obj2.str = "Some other String";
            List<MyObject> list = new List<MyObject>();
            list.Add(obj);
            list.Add(obj2);
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Append,FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, list);
            stream.Close();
        }
        public static void read()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("MyFile.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<MyObject> list = (List<MyObject>)formatter.Deserialize(stream);
            stream.Close();
        }
