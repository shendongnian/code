        if (entity.SecondaryMealId == -1)
        {
            mailMessage.Body = entity.PrimaryMeal.Title + ".<br>Porosine mund ta beni ketu: http://10.200.30.11:8888";
        }
        else if (entity.TertiaryMealId == -1)
        {
            mailMessage.Body = entity.PrimaryMeal.Title + ",<br>" + entity.SecondaryMeal.Title + ".\r\nPorosine mund ta beni ketu: http://10.200.30.11:8888";
        }
        else
        {
            mailMessage.Body = entity.PrimaryMeal.Title + ",<br>" + entity.SecondaryMeal.Title + ",<br>" + entity.TertiaryMeal.Title + ".<br>Porosine mund ta beni ketu: http://10.200.30.11:8888";
        }
