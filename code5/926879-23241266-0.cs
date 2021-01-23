    Queue<Customer> aQueue = new Queue<Customer>();
    Customer customer = new Customer { Name = "Test" };
    aQueue.Enqueue(customer);
    customer = new Customer { Name = "Test1" };
    aQueue.Enqueue(customer);
    customer = new Customer { Name = "Test2" };
    aQueue.Enqueue(customer);
    while (aQueue.Any())
    {
        customer = aQueue.Dequeue();
        // use customer
    }
