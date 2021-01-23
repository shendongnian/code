    public Tree leftChild { get; set; }
    public Tree rightChild { get; set; }
    public object value { get; set; }   
    public void InOrder()
    {
        if(this.leftChild != null)
        {
            this.leftChild.InOrder();
        }
        Console.WriteLine(this.value);
        if(this.rightChild != null)
        {
            this.rightChild.InOrder();
        }
    }
