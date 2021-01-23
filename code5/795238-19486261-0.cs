     void LoadArrayList()
    {
        string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Maattt\Documents\Visual Studio 2010\Projects\actor\actors.txt");
       // Display the file contents by using a foreach loop.
       foreach (string Actor in lines)
       {
           ActorArrayList.Add(Actor);
      }
    }
