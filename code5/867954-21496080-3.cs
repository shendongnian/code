    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Packer
    {
        public class SimplePack
        {
            public class Header
            {
                public Int32 TotalEntries { get; set; }
                public Int64[] EntriesSize
                {
                    get
                    {
                        return EntriesSizeList.ToArray();
                    }
                }
                private List<Int64> EntriesSizeList { get; set; }
    
                public Header()
                {
                    TotalEntries = 0;
                    EntriesSizeList = new List<Int64>();
                }
    
                public void AddEntrySize(Int64 newSize)
                {
                    EntriesSizeList.Add(newSize);
                }
            }
    
            public class Item
            {
                public Byte[] RawData { get; set; }
                public String Name { get; set; }
                public String RelativeUri { get; set; }
    
                public Int64 ItemSize
                {
                    get
                    {
                        Int64 retVal = 4; //Name.Lenght;
                        retVal += Name.Length;
                        retVal += 4; //RelativeUri.Length
                        retVal += RelativeUri.Length;
                        retVal += RawData.Length;
    
                        return retVal;
                    }
                }
    
                public Byte[] SerializedData
                {
                    get
                    {
                        List<Byte> retVal = new List<Byte>();
                        retVal.AddRange(BitConverter.GetBytes(Name.Length));
                        retVal.AddRange(Encoding.Default.GetBytes(Name));
                        retVal.AddRange(BitConverter.GetBytes(RelativeUri.Length));
                        retVal.AddRange(Encoding.Default.GetBytes(RelativeUri));
                        retVal.AddRange(RawData);
                        return retVal.ToArray();
                    }
                }
    
                public Item()
                {
                    RawData = new Byte[0];
                    Name = String.Empty;
                    RelativeUri = String.Empty;
                }
                public Item(Byte[] serializedItem)
                {
                    Int32 Cursor = 0;
                    Int32 nl = BitConverter.ToInt32(serializedItem, Cursor);
                    Cursor += 4;
                    Name = Encoding.Default.GetString(serializedItem, Cursor, nl);
                    Cursor += nl;
                    Int32 rl = BitConverter.ToInt32(serializedItem, Cursor);
                    Cursor += 4;
                    RelativeUri = Encoding.Default.GetString(serializedItem, Cursor, rl);
                    Cursor += rl;
                    RawData = new Byte[serializedItem.Length - Cursor];
                    for (int i = Cursor; i < serializedItem.Length; i++)
                    {
                        RawData[i - Cursor] = serializedItem[Cursor];
                    }
                }
            }
    
            public FileInfo PackedFile { get; private set; }
            public List<Item> Data { get; private set; }
    
            public Header FileHeaderDefinition { get; private set; }
    
            public SimplePack(String fileName)
            {
                PackedFile = new FileInfo(fileName);
                FileHeaderDefinition = new Header();
                Data = new List<Item>();
            }
    
            public Boolean PackFolderContent(String folderFullName)
            {
                Boolean retVal = false;
    
                DirectoryInfo di = new DirectoryInfo(folderFullName);
    
                //Think about setting up strong checks and errors trapping
    
                if (di.Exists)
                {
                    FileInfo[] files = di.GetFiles("*", SearchOption.AllDirectories);
                    foreach (FileInfo fi in files)
                    {
                        Item it = setItem(fi, di.FullName);
                        if (it != null)
                        {
                            Data.Add(it);
                            FileHeaderDefinition.TotalEntries++;
                            FileHeaderDefinition.AddEntrySize(it.ItemSize);
                        }
                    }
                }
                //althoug it isn't checked
                retVal = true;
    
                return retVal;
            }
    
            private Item setItem(FileInfo sourceFile, String packedRoot)
            {
                if (sourceFile.Exists)
                {
                    Item retVal = new Item();
                    retVal.Name = sourceFile.Name;
                    retVal.RelativeUri = sourceFile.FullName.Substring(packedRoot.Length).Replace("\\", "/");
                    retVal.RawData = File.ReadAllBytes(sourceFile.FullName);
                    return retVal;
                }
                else
                {
                    return null;
                }
            }
    
            public void Save()
            {
                if (PackedFile.Exists)
                {
                    PackedFile.Delete();
                    System.Threading.Thread.Sleep(100);
                }
                using (FileStream fs = new FileStream(PackedFile.FullName, FileMode.CreateNew, FileAccess.Write))
                {
                    //Writing Header
                    //4 bytes
                    fs.Write(BitConverter.GetBytes(FileHeaderDefinition.TotalEntries), 0, 4);
                    //8 bytes foreach size
                    foreach (Int64 size in FileHeaderDefinition.EntriesSize)
                    {
                        fs.Write(BitConverter.GetBytes(size), 0, 8);
                    }
                    foreach (Item it in Data)
                    {
                        fs.Write(it.SerializedData, 0, it.SerializedData.Length);
                    }
    
                    fs.Close();
                }
            }
    
            public void Open()
            {
                if (PackedFile.Exists)
                {
                    using (FileStream fs = new FileStream(PackedFile.FullName, FileMode.Open, FileAccess.Read))
                    {
                        Byte[] readBuffer = new Byte[4];
                        fs.Read(readBuffer, 0, readBuffer.Length);
                        FileHeaderDefinition.TotalEntries = BitConverter.ToInt32(readBuffer, 0);
                        for (Int32 i = 0; i < FileHeaderDefinition.TotalEntries; i++)
                        {
                            readBuffer = new Byte[8];
                            fs.Read(readBuffer, 0, readBuffer.Length);
                            FileHeaderDefinition.AddEntrySize(BitConverter.ToInt64(readBuffer, 0));
                        }
    
                        foreach (Int64 size in FileHeaderDefinition.EntriesSize)
                        {
                            readBuffer = new Byte[size];
                            fs.Read(readBuffer, 0, readBuffer.Length);
                            Data.Add(new Item(readBuffer));
                        }
    
                        fs.Close();
                    }
                }
            }
    
    
    
    
        }
    }
    
