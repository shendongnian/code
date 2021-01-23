    private LnkedList<Program> _Programs = new LinkedList<Program>();
    
    public void menu()
    {
        Console.WriteLine("\n Choose what to do :\n1. Add new Entry\n2. Search Phone\n3.quit\n");
    
        int choice = Convert.ToInt16(Console.ReadLine());
        switch(choice)
        {
            case 1: DetailAccept();
                AddL(getName(), getCellNo(), _Programs);
    
        }
    }
