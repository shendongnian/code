    var benefits = customerBenefits.Select(n =>
            new CustomerBenefit(
                n.BenefitID,                   
                n.AddedByUserID.HasValue 
                    ? (UserService.GetByUserID(n.AddedByUserID.Value) == null 
                        ? String.Empty 
                        : UserService.GetByUserID(n.AddedByUserID.Value).
                            DisplayName) 
                : n.AddedByAgentID,
                n.Reason);
