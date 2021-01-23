        Console.Write("\nEnter employees name: ");
        employeeName = Console.ReadLine();
        Console.Write("Enter the total sales amount for the week:");
        totalSales = Convert.ToDecimal(Console.ReadLine());
        //Create an instance of your second class...
        var employee = new Employee(employeeName,totalSales);
        Console.Write(employee);
