    var validStatues = new int[] {1, 3, 2};
    if (!validStatues.Any(x=>x == statusId))
    {
        statusId = 0;
    }
    
    var statuses = new Dictionary<int, Func<SmsStatusEnum>>
    {
        {1,()=> SmsStatusEnum.Sent},
        {2,()=> SmsStatusEnum.Delivered},
        {3,()=> SmsStatusEnum.Failed},
        {0,()=> SmsStatusEnum.Failed},
    };
