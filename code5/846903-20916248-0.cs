        from user in context.UserProfiles
                        from business in context.BusinessProfiles
                        join bid in context.Bids on new { UserProfileId = user.Id, BusinessProfileId = business.Id } equals new { bid.UserProfileId, bid.BusinessProfileId }
                        join tender in context.Tenders on new { TenderId = bid.TenderId } equals new { TenderId = tender.Id }
                        where business.Id == businessProfileId && user.Id == userProfileId && tender.Id == tenderId
    select new CustomObject
    {
    ...
    }
