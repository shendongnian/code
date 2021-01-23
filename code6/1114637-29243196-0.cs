    class Program
    {
        public class Kart
        {
            public long Id { get; set; }
            public long? ParentId { get; set; }
            public string Name { get; set; }
        }
        public class KartVM
        {
            public long Id { get; set; }
            public long? ParentId { get; set; }
            public string Hierarchy { get; set; }
            public string Name { get; set; }
        }
    
        static void Main(string[] args)
        {
            List<Kart> list = new List<Kart>
            {
                new Kart {Id = 1, ParentId = null, Name = "Main Content1"},
                new Kart {Id = 2, ParentId = 1, Name = "Main Content1"},
                new Kart {Id = 3, ParentId = 1, Name = "Main Content1"},
                new Kart {Id = 4, ParentId = 1, Name = "Main Content1"},
                new Kart {Id = 5, ParentId = 3, Name = "Main Content1"},
                new Kart {Id = 6, ParentId = 3, Name = "Main Content1"},
                new Kart {Id = 7, ParentId = 4, Name = "Main Content1"},
                new Kart {Id = 8, ParentId = 4, Name = "Main Content1"},
                new Kart {Id = 9, ParentId = 8, Name = "Main Content1"},
                new Kart {Id = 10, ParentId = 8, Name = "Main Content1"},
                new Kart {Id = 11, ParentId = 8, Name = "Main Content1"},
                new Kart {Id = 12, ParentId = 11, Name = "Main Content1"},
                new Kart {Id = 13, ParentId = 11, Name = "Main Content1"},
                new Kart {Id = 14, ParentId = 13, Name = "Main Content1"},
                new Kart {Id = 15, ParentId = null, Name = "Main Content1"},
                new Kart {Id = 16, ParentId = 15, Name = "Main Content1"},
                new Kart {Id = 17, ParentId = 16, Name = "Main Content1"},
                new Kart {Id = 18, ParentId = 17, Name = "Main Content1"},
                new Kart {Id = 19, ParentId = 18, Name = "Main Content1"},
                
    
                
    
            };
            List<KartVM> theResult = new List<KartVM>();
            GetHierachicalList(list, theResult, null, "");
    
            foreach(KartVM t in theResult)
            {
                Console.WriteLine(t.Hierarchy);
            }
            Console.ReadLine();
        }
        static void GetHierachicalList(List<Kart> kart, List<KartVM> kartVM, Kart currentNode, string curH)
        {
            List<Kart> tmp = new List<Kart>();
            if (currentNode == null)
                tmp = kart.Where(c => c.ParentId == null).ToList();
            else
                tmp = kart.Where(c => c.ParentId == currentNode.Id).ToList();
            int count = 1;
            foreach(Kart k in tmp)
            {
    
                KartVM tmpVM = new KartVM { Id = k.Id, Name = k.Name, ParentId = k.ParentId };
                tmpVM.Hierarchy += curH + "." + count.ToString();
                if (tmpVM.Hierarchy.StartsWith("."))
                    tmpVM.Hierarchy = tmpVM.Hierarchy.Remove(0, 1);
                kartVM.Add(tmpVM);
                count++;
                GetHierachicalList(kart, kartVM, k, tmpVM.Hierarchy);
    
            }
        }
    }
