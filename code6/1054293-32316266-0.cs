        public IObjectContainer Container { get; set; }
        public void NewItem(string contactId, string emailAddress)
        {
            IAgent agent = Container.Resolve<IAgent>();
            IRoutingBasedManager routingManager = Container.Resolve<IRoutingBasedManager>();
            IDictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("CommandParameter", agent.FirstMediaEmail);
            parameters.Add("TargetId", contactId);
            parameters.Add("OwnerId", agent.ConfPerson.EmailAddress);
            parameters.Add("Destination", emailAddress);
            parameters.Add("RecentIndex", contactId);
            bool todo = routingManager.RequestToDo("CreateNewOutboundEmail", RoutingBasedTarget.Contact, parameters);
            if (todo && parameters.ContainsKey("RoutingBaseCommand"))
            {
                IChainOfCommand chainOfCommand = parameters["RoutingBaseCommand"] as IChainOfCommand;
                if (chainOfCommand != null)
                {
                    chainOfCommand.Execute(parameters["RoutingBaseCommandParameters"]);
                }
            }
        }
