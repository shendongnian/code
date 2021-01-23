    private ContractDescription CopyContract(ContractDescription contract)
        {
            //ContractDescription orgContract = _host.Description.Endpoints[1].Contract;
            ContractDescription value = new ContractDescription("IServiceWithCallBack");
            //copy the value from orgiginal to the new contract.
            foreach (var item in contract.Behaviors)
            {
                value.Behaviors.Add(item);
            }
            value.ConfigurationName = contract.ConfigurationName;
            value.ContractType = contract.ContractType;
            foreach (var item in contract.Operations)
            {
                OperationDescription operation = new OperationDescription(item.Name, value);
                operation.BeginMethod = item.BeginMethod;
                foreach (var behavior in item.Behaviors)
                {
                    operation.Behaviors.Add(behavior);
                }
                operation.EndMethod = item.EndMethod;
                foreach (var fault in item.Faults)
                {
                    operation.Faults.Add(fault);
                }
                operation.IsInitiating = item.IsInitiating;
                operation.IsTerminating = item.IsTerminating;
                foreach (var knownType in item.KnownTypes)
                {
                    operation.KnownTypes.Add(knownType);
                }
                foreach (var message in item.Messages)
                {
                    operation.Messages.Add(message);
                }
                operation.ProtectionLevel = item.ProtectionLevel;
                operation.SyncMethod = item.SyncMethod;
                value.Operations.Add(operation);
            }
            value.ProtectionLevel = contract.ProtectionLevel;
            value.SessionMode = contract.SessionMode;
            List<OperationDescription> removeList = new List<OperationDescription>();
            foreach (var item in value.Operations)
            {
                if (item.Name.ToLower().EndsWith("callback"))
                    removeList.Add(item);
            }
            foreach (var item in removeList)
            {
                value.Operations.Remove(item);
            }
            return value;
        }
