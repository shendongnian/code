            var client = new Client { CriminalRecord = false, UsesCreditCard = true, YearsInJob = 10, Income = 70000 };
            var reliableAndWealthy = from reliable in ClientDecisions.Reliable
                                     from wealthy in ClientDecisions.Wealthy
                                     select wealthy;
            if (reliableAndWealthy(client).HasValue)
            {
                Console.WriteLine("They're reliable AND wealthy");
            }
            var reliableOrWealthyAndStable = from reliableOrWealthy in ClientDecisions.Reliable.Or( ClientDecisions.Wealthy )
                                             from stable in ClientDecisions.Stable
                                             select stable;
            if (reliableOrWealthyAndStable(client).HasValue)
            {
                Console.WriteLine("They're reliable OR wealthy, AND stable");
            }
            var reliableAndWealthyAndStable = from reliable in ClientDecisions.Reliable
                                              from wealthy in ClientDecisions.Wealthy
                                              from stable in ClientDecisions.Stable
                                              select stable;
            if (reliableOrWealthyAndStable(client).HasValue)
            {
                Console.WriteLine("They're reliable OR wealthy, AND stable");
            }
