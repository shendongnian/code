    class Program
    {
        static void Main(string[] args)
        {
            List<FlatObject> objects = new List<FlatObject>();
            objects.Add(new FlatObject { ID = 1, ParentID = 0, Name = "January", Amount = 1000 });
            objects.Add(new FlatObject { ID = 2, ParentID = 0, Name = "February", Amount = 2000 });
            objects.Add(new FlatObject { ID = 3, ParentID = 0, Name = "March", Amount = 3000 });
            objects.Add(new FlatObject { ID = 4, ParentID = 0, Name = "April", Amount = 4000 });
            objects.Add(new FlatObject { ID = 5, ParentID = 0, Name = "May", Amount = 5000 });
            objects.Add(new FlatObject { ID = 6, ParentID = 1, Name = "June", Amount = 6000 });
            objects.Add(new FlatObject { ID = 7, ParentID = 1, Name = "July", Amount = 7000 });
            objects.Add(new FlatObject { ID = 8, ParentID = 1, Name = "August", Amount = 8000 });
            objects.Add(new FlatObject { ID = 9, ParentID = 2, Name = "September", Amount = 9000 });
            objects.Add(new FlatObject { ID = 10, ParentID = 2, Name = "October", Amount = 10000 });
            objects.Add(new FlatObject { ID = 11, ParentID = 2, Name = "November", Amount = 11000 });
            objects.Add(new FlatObject { ID = 12, ParentID = 10, Name = "December", Amount = 12000 });
            objects.Add(new FlatObject { ID = 13, ParentID = 10, Name = "January", Amount = 13000 });
            objects.Add(new FlatObject { ID = 14, ParentID = 10, Name = "February", Amount = 14000 });
            objects.Add(new FlatObject { ID = 15, ParentID = 3, Name = "March", Amount = 15000 });
            objects.Add(new FlatObject { ID = 16, ParentID = 3, Name = "April", Amount = 16000 });
            objects.Add(new FlatObject { ID = 17, ParentID = 3, Name = "May", Amount = 17000 });
            objects.First(x=>x.ID==2).GetAllChildren(objects).ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
    public class FlatObject
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public override string ToString()
        {
            return string.Format("ID={0} ParentID={1} Name={2} Amount={3} ", ID, ParentID, Name, Amount);
        }
    }
    public static class FlatObjectExtention
    {
        public static IList<FlatObject> GetAllChildren(this FlatObject flatObject, IList<FlatObject> allItems)
        {
            var allChildren = new List<FlatObject>();
            var children = allItems.Where(x => x.ParentID == flatObject.ID).ToList();
            allChildren.AddRange(children);
            foreach (var child in children)
            {
                allChildren.AddRange(child.GetAllChildren(allItems));
            }
            return allChildren;
        }
    }
