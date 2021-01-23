     // Wait until you get the information of the user
     if (!_routingCategoryUpdated.WaitOne(10000))
            {
                Console.WriteLine("TimeOut Getting Informations");
                return;
            }
     // Just display all the data you can need
     else
            {
                Console.WriteLine($"User Aor: {userEndPointTarget.OwnerUri}");
                Console.WriteLine($"Display Name: {userEndPointTarget.OwnerDisplayName}");
                Console.WriteLine($"UM Enabled: {userEndPointTarget.UmEnabled}");
                Console.WriteLine($"Simulring enabled: {_routingCategory.SimultaneousRingEnabled}");
                if (_routingCategory.SimultaneousRingEnabled && _routingCategory.SimultaneousRing != null)
                {
                    foreach (string time in _routingCategory.SimultaneousRing)
                    {
                        Console.WriteLine($"Simul_Ringing to: {time}");
                    }
                }
                if (_routingCategory.DelegateRingEnabled)
                {
                    if (_routingCategory.SkipPrimaryEnabled)
                    {
                        Console.Out.Write("Forwarding calls to Delegates: ");
                    }
                    else if (_routingCategory.UserWaitTimebeforeTeamOrDelegates.TotalSeconds > 0.0)
                    {
                        Console.Out.Write($"Delay Ringing Delegates (delay:{ _routingCategory.UserWaitTimebeforeTeamOrDelegates.TotalSeconds} seconds): ");
                    }
                    else
                    {
                        Console.Out.Write("Simultaneously Ringing Delegates: ");
                    }
                    foreach (string delegateCurrent in _routingCategory.Delegates)
                    {
                        Console.Out.Write($"{delegateCurrent} ");
                    }
                    Console.Out.WriteLine();
                }
                else if (_routingCategory.TeamRingEnabled)
                {
                    if (_routingCategory.UserWaitTimebeforeTeamOrDelegates.TotalSeconds > 0.0)
                    {
                        Console.Out.Write($"Delay Ringing Team (delay:{_routingCategory.UserWaitTimebeforeTeamOrDelegates.TotalSeconds} seconds). Team: ");
                    }
                    else
                    {
                        Console.Out.Write("Team ringing enabled. Team: ");
                    }
                    foreach (string currentTeam in _routingCategory.Team)
                    {
                        Console.Out.Write($"{currentTeam} ");
                    }
                    Console.Out.WriteLine();
                }
                else if (_routingCategory.CallForwardToTargetsEnabled)
                {
                    if (_routingCategory.CallForwardingEnabled)
                    {
                        Console.Out.WriteLine($"Forward immediate to: {_routingCategory.CallForwardTo}");
                    }
                    else
                    {
                        Console.Out.WriteLine($"User Ring time: {_routingCategory.UserOnlyWaitTime}");
                        Console.Out.WriteLine($"Call Forward No Answer to: {_routingCategory.CallForwardTo[0]}");
                    }
                }
                else if (userEndPointTarget.UmEnabled)
                {
                    Console.Out.WriteLine($"User Ring time: {_routingCategory.UserOnlyWaitTime}");
                    Console.Out.WriteLine("Call Forward No Answer to: voicemail");
                }
                else
                {
                    Console.Out.WriteLine("CallForwarding Enabled: false");
                }
