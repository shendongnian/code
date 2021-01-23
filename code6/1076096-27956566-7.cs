    public Form1()
    {
        InitializeComponent();
        int tenantCount = 2;
        // Start each person out splitting the total expenses
        pattiExpenses = new Expenses
        {
            Electricity = totalExpenses.Electricity / tenantCount,
            Groceries = totalExpenses.Groceries / tenantCount,
            Internet = totalExpenses.Internet / tenantCount,
            Rent = totalExpenses.Rent / tenantCount,
            TV = totalExpenses.TV / tenantCount,
            Water = totalExpenses.Water / tenantCount
        };
        mikeExpenses = new Expenses
        {
            Electricity = totalExpenses.Electricity / tenantCount,
            Groceries = totalExpenses.Groceries / tenantCount,
            Internet = totalExpenses.Internet / tenantCount,
            Rent = totalExpenses.Rent / tenantCount,
            TV = totalExpenses.TV / tenantCount,
            Water = totalExpenses.Water / tenantCount
        };
        UpdateTextBoxes();
    }
