    Call service first then assign result.
           
    var benefits = customerBenefits
                            .Select(n => {
                                var user = serService.GetByUserID(n.AddedByUserID.Value);
                                
                                return new CustomerBenefit(
                                    n.BenefitID,                   
                                    n.AddedByUserID.HasValue ? (user== null ? String.Empty : ).DisplayName) : n.AddedByAgentID,
                                    n.Reason} );
