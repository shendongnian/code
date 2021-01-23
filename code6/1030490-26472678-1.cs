        public override Func<HubDescriptor, IRequest, IList<string>, IList<string>> BuildRejoiningGroups(
            Func<HubDescriptor, IRequest, IList<string>, IList<string>> rejoiningGroups)
        {
            return (hb, r, l) =>
            {
                // Get the groups SignalR would rejoin the client to by default
                var groupsToRejoin = rejoiningGroups(hb, r, l);
                // I would ensure that groupsToRejoin doesn't already contain the group
                // GetTaskToken would add, because SignalR will rejoin the group automatically
                // if the client has already be added to the group.
                if (r.Headers.Any(h => h.Key == "Referer"))
                {
                    groupsToRejoin.Add(GetTaskToken(r));
                }
                return groupsToRejoin;
            };
        }
