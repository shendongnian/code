    public static void Main(string[] args)
    {
      var runner = new Runner();
      runner.Run();
    }
    public void Run()
    {
      var items = ...
      Parallel.ForEach(items, i => this.RunItem(i));
    }
    private void RunItem(Item i)
    {
      var subItems = i.GetSubItems();
      Parallel.ForEach(subItems, s => s.RunSubItem(s));
      this.Process(i);
    }
    private void RunSubItem(SubItem s)
    {
      ...
    }
