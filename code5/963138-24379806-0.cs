    var benefits = customerBenefits
                    .Select(n =>
                        new CustomerBenefit(
                            n.BenefitID,                   
                            n.AddedByUserID.HasValue ? ((UserService.GetByUserID(n.AddedByUserID.Value) != null)?UserService.GetByUserID(n.AddedByUserID.Value).DisplayName : string.Empty) : n.AddedByAgentID,
                            n.Reason);
