    var original = new DateTime(635338107839470268);
    var Ticks = (original - new DateTime(1970,1,1)).Ticks;
    // Ticks is now 13982139839470268
    
    var back = new DateTime(1970,1,1).AddTicks(13982139839470268);
    //back.Ticks is 635338107839470268
