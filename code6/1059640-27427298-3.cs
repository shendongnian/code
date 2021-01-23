    public class Program
        {
            private static void Main(string[] args)
            {
                //Create test data and add it to a collection
                var collection = DummyData();
    
                //Serialize the collection to XML and write to console.
                Console.WriteLine(collection.SerializeToXML());
                
                //Prevents console window from closing
                Console.ReadLine();
            }
    
            /// <summary>
            /// Generates dummy data for testing purposes
            /// </summary>
            /// <returns>A collection of RUBIObjects</returns>
            private static RUBIObjectCollection DummyData()
            {
                Random random = new Random();
                var collection = new RUBIObjectCollection();
    
                //Build a collection of RUBIObjects and instantiate them with semi-random data.
                for (int i = 0; i < 10; i++)
                {
                    int month = random.Next(1, 12);     //Random month as an integer
                    int year = random.Next(2010, 2015); //Random year as an integer
    
                    //Create object and add to collection.
                    collection.Objects.Add(new RUBIObject()
                        {
                            ID = Guid.NewGuid(),
                            Name = string.Format("Object{0}", i),
                            Description = "Description",
                            CreatedOn = new DateTime(year, month, 1)
                        });
                }
    
                return collection;
            }
        }
