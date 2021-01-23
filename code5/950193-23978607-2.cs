    var firstTrigger = new CronTriggerImpl();
    firstTrigger.CronExpressionString = "0 0 0/1 1/1 * ? *";
    firstTrigger.StartTimeUtc = new DateTime(2014, 05, 31, 15, 44, 00).ToUniversalTime();
    Console.WriteLine("first trigger fire times:");
    Console.WriteLine(string.Join(Environment.NewLine, TriggerUtils.ComputeFireTimes(firstTrigger, null, 6).Select(x => x.ToLocalTime())));
    
    var secondTrigger = new CronTriggerImpl();
    secondTrigger.CronExpressionString = "0 44 15 ? * SUN,MON *";
    secondTrigger.StartTimeUtc = new DateTime(2014, 05, 31, 15, 44, 00).ToUniversalTime();
    Console.WriteLine("second trigger fire times:");
    Console.WriteLine(string.Join(Environment.NewLine, TriggerUtils.ComputeFireTimes(secondTrigger, null, 6).Select(x => x.ToLocalTime())));
