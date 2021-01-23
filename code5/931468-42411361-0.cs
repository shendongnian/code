    IEnumerable<ActivityParty> party = new[] { new ActivityParty { LogicalName = ActivityParty.EntityLogicalName , PartyId = eref2  } };
                        Console.WriteLine("Logging activity to {0}", firstName);
                        Console.WriteLine("... \n" );
                        PhoneCall newCall = new PhoneCall { Description = "Missed phone call from this lead", DirectionCode = true, RegardingObjectId = eref2,
                            Subject = "Missed Call", PhoneNumber = MissedCall, OwnerId = User, From = party };
                        
                        Guid newCallId = service.Create(newCall);
                    Console.WriteLine("Log successfully created \n \n ");
