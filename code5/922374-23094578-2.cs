     var town = Console.ReadLine();
     var record = File.ReadLines("filepath")
                  .Where(x => x != string.Empty)
                  .Select((line, idx) => new {line, idx})
                  .GroupBy(x => x.idx/6)
                  .FirstOrDefault(x => x.Any(e => e.line.Contains(town)));
    if (record != null)
    {
         var values = record.Select(x => x.line).ToArray();
         Console.WriteLine("Customer No: {0}", values[0]);
         Console.WriteLine("Customer Surname: {0}", values[1]);
         Console.WriteLine("Customer Forename: {0}", values[2]);
         Console.WriteLine("Customer Street: {0}", values[3]);
         Console.WriteLine("Customer Town: {0}", values[4]);
         Console.WriteLine("Customer Day Of Birth: {0}", values[5]);
    }
