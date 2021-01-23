    private readonly DecisionNode<Client> _isReliableTree =
        DecisionNode.Create<Client>("Criminal record", client => client.CriminalRecord)
            .WhenTrue(false)
            .WhenFalse(DecisionNode.Create<Client>("Credit card", 
                                                   client => client.UsesCreditCard)
               .WhenFalse(DecisionNode.Create<Client>("More than $40k", 
                                                      client => client.Income > 40000)
                  .WhenFalse(DecisionNode.Create<Client>("More than 2 years in job", 
                                                         client => client.YearsInJob > 2))));
