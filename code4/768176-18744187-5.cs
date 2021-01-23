    public static void Main()
    {
      var queue = new BlockingCollection<YourData>();
      var producer = new Producer(queue);
      var consumer = new Consumer(queue);
      producer.GenerateItems();
    }
