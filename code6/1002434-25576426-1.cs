            var domainControllers = new List<string>();
            var domain = Domain.GetCurrentDomain();
            foreach (var dc in domain.DomainControllers)
            {
                domainControllers.Add(dc.Name);
            }
            string whoami = Dns.GetHostname();
