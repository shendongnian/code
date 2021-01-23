    public void CalculationMethod(delegate myFunction) // need to look up correct param syntax
    {
        foreach (Order order in ordersList)
        {
            foreach (Detail obj_detail in order.Details)
            {
                myFunction(); // Need to lookup correct calling syntax
            }
        }
    }
