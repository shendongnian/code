    foreach (var item in caseList)
        {
            Console.WriteLine(item.Year);
            foreach (var agency in item.Agencies)
            {
                Console.WriteLine( agency.Agency + " Number Cases:" + agency.Total + " Number Attorneys:" + agency.Attorneys.Count());
                foreach (var attorney in agency.Attorneys)
                {
                    Console.WriteLine(attorney.Attorney + " Number Cases: " + attorney.Total );
                    foreach (var cases in attorney.Cases)
                    {
                        Console.WriteLine("Case #" + cases.CaseNumber);
                    }
                }
            }
        }
            Console.ReadKey();
        }
