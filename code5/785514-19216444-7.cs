    public class Program
    {
        public struct hashedFile : IEquatable<hashedFile>
        {
            string _fileString;
            byte[] _fileHash;
            public hashedFile(string fileString, byte[] fileHash)
            {
                this._fileString = fileString;
                this._fileHash = fileHash;
            }
            public string FileString { get { return _fileString; } }
            public byte[] FileHash { get { return _fileHash; } }
            public bool Equals(hashedFile other)
            {
                return _fileString == other._fileString && _fileHash.SequenceEqual(other._fileHash);
            }
        }
        public static void Main(string[] args)
        {
            List<hashedFile> list1 = GetList1();
            List<hashedFile> list2 = GetList2();
            List<hashedFile> diff = list1.Except(list2).ToList();
            foreach (hashedFile h in diff)
            {
                Console.WriteLine(h.FileString + Environment.NewLine + h.FileHash[0].ToString("x2"));
            }
            Console.ReadLine();
        }
        private static List<hashedFile> GetList1()
        {
            hashedFile one = new hashedFile("test1", BitConverter.GetBytes(1));
            hashedFile two = new hashedFile("test2", BitConverter.GetBytes(2));
            hashedFile threeA = new hashedFile("test3", BitConverter.GetBytes(4));
            hashedFile four = new hashedFile("test4", BitConverter.GetBytes(4));
            var list1 = new List<hashedFile>();
            list1.Add(one);
            list1.Add(two);
            list1.Add(threeA);
            list1.Add(four);
            return list1;
        }
        private static List<hashedFile> GetList2()
        {
            hashedFile one = new hashedFile("test1", BitConverter.GetBytes(1));
            hashedFile two = new hashedFile("test2", BitConverter.GetBytes(2));
            hashedFile three = new hashedFile("test3", BitConverter.GetBytes(3));
            var list1 = new List<hashedFile>();
            list1.Add(one);
            list1.Add(two);
            list1.Add(three);
            return list1;
        }
    }
