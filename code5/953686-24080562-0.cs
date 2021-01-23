    totalTickets = context.EventParentSponsors.Join(context.EventSponsors, 
                                                    x=>x.EventSponsorId,
                                                    y=>y.EventSponsorId,
                                                    (x,y) =>
                                                    new 
                                                    {
                                                        ID=x.ParentSponsorID , 
                                                        Count = x.InvitationCount 
                                                    })
                                              .Where(x=>x.ID==parentId)
                                              .Select(x=>x.Count)
                                              .FirstOrDefault();
