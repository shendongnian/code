    public int ID
    {
        set
        {
            id = value;
        }
    }
    private string name =null;
    public string Name
    {
        set
        {
            name = value;
        }
    }
    public void DisplayCustomerData()
    {
        Console.WriteLine("ID: {0}, Name:
            {1}", id, name);
    }
