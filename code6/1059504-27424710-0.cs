            foreach (var partner in user.Partners)
            {
                foreach (var tm in partner.Programmes.SelectMany(programme => programme.TeamMembers)) {
                    if (!dict.ContainsKey(tm.ApplicationUserId))
                    {
                        dict.Add(tm.ApplicationUserId, new List<int> { partner.Id });
                        allUsers.Add(tm.ApplicationUser);
                    }
                    else
                    {
                        dict[tm.ApplicationUserId].Add(partner.Id);
                    }
                }
            }
