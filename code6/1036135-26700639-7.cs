            var client = new Client { CriminalRecord = false, UsesCreditCard = true, YearsInJob = 10, Income = 70000 };
            var decision = from reliable in ClientDecisions.Reliable
                           from wealthy in ClientDecisions.Wealthy
                           select "They're reliable AND wealthy";
            var result = decision(client);
            if (result.HasValue)
            {
                Console.WriteLine(result.Value);
            }
            decision = from reliableOrWealthy in ClientDecisions.Reliable.Or(ClientDecisions.Wealthy)
                       from stable in ClientDecisions.Stable
                       select "They're reliable OR wealthy, AND stable";
            result = decision(client);
            if (result.HasValue)
            {
                Console.WriteLine(result.Value);
            }
            decision = from reliable in ClientDecisions.Reliable
                       from wealthy in ClientDecisions.Wealthy
                       from stable in ClientDecisions.Stable
                       select "They're reliable AND wealthy, AND stable";
            result = decision(client);
            if (result.HasValue)
            {
                Console.WriteLine(result.Value);
            }
