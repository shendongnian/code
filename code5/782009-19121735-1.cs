    public class Example
    {
      // This is the immutable master collection.
      volatile List<string> collection = new List<string>();
    
      void Writer()
      {
        var copy = new List<string>(collection); // Snapshot the collection.
        copy.Add("hello world"); // Modify the snapshot.
        collection = copy; // Publish the snapshot.
      }
    
      void Reader()
      {
        List<string> local = collection; // Acquire a local reference for safe reading.
        if (local.Count > 0)
        {
          DoSomething(local[0]);
        }
      }
    }
