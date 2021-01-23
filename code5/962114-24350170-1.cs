            var commissionAndReferrals = 
                from c in Commissions
                where c.TransferStatus == "Paid"
                where c.AdminHasReleased == false
                join r in ReferralMatches on c.ReferralMatchId equals r.ReferralMatchId
                select new { Commisson = c, Referral = r };
            var result =
                from cAndR in commissionAndReferrals
                group cAndR by cAndR.Commisson.TransferId into transferGroup
                select new
                {
                    TransferId = transferGroup.Key,
                    Charges = from c in transferGroup
                              group c by c.Commisson.ChargeId into chargeGroup
                              select new
                              {
                                  ChargeId = chargeGroup.Key,
                                  Referrals = chargeGroup.Select(x => x.Referral)
                              }
                };
