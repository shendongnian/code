    using (var ps = PowerShell.Create()) {
        while (true) {
            Console.WriteLine("Enter an expression:");
            string input = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(input)) break;
            ps.AddScript(input);
            Collection<PSObject> results = ps.Invoke();
            foreach (var result in results) {
                Console.WriteLine(result);
            }
        }
    }
