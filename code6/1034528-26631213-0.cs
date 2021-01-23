    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    //where the magic lives
    using System.Runtime.Serialization.Formatters.Binary;
    namespace savecon
    {
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            byte[] data = new byte[20];
            rand.NextBytes(data);
            DataObj a = new DataObj(data);
            DataObj b = new DataObj(data);
            DataCollection dc_old = new DataCollection();
            dc_old.Add(a);
            dc_old.Add(b);
            DataCollection.ToFile("D:\\data.my",dc_old);//I use D: drive yours will be different
            DataCollection dc_new = DataCollection.FromFile("D:\\data.my");
            
        }
    }
    [Serializable]//the magic
    struct DataObj
    { 
        byte[] data;
        public DataObj(byte[] d)
        {
            data = d;
        }
    }
    [Serializable]//more magic
    class DataCollection : IEnumerable<DataObj>
    {
        List<DataObj> dataobjects;//list<> is Attributed with Serializable as well
        public DataCollection()
        {
            dataobjects = new List<DataObj>();
        }
        public static DataCollection FromFile(string path)
        {
            DataCollection dcol;
            using (FileStream FS = File.OpenRead(path))
            {
                dcol = (DataCollection)new BinaryFormatter().Deserialize(FS); // magic happening
            }
            return dcol;
        }
        
        public static void ToFile(string path,DataCollection DC)
        {
            using (FileStream FS = File.Open(path, FileMode.Create, FileAccess.ReadWrite))
            {
                new BinaryFormatter().Serialize(FS, DC);
            }
        }
        public void Add(DataObj dobj)
        {
            dataobjects.Add(dobj);
        }
        
        //note that Ienumerable does not matter for serializing (saving the data)
        public IEnumerator<DataObj> GetEnumerator()
        {
            return dataobjects.AsEnumerable().GetEnumerator();
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return dataobjects.GetEnumerator();
        }
    }
    }
