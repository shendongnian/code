    int id = 1;
    LinkedListNode<IHaveID> nodes = null;
    LinkedList<IHaveID> testList = new LinkedList<IHaveID>();
    var item = testList.FirstOrDefault(x => x.ID == id);
    if(item != null)
    {
        nodes = testList.Find(item);
    }
    
