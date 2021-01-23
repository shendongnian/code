    var megaMean = _db.GetMegaMillionsMean();
    var powerMean = _db.GetPowerballMean();
    //object mega = null;
    List<mega> viewMega = megaMean.Select(p => new mega {ball1 = p.Ball_1_Average, ball2 = p.Ball_2_Average, ball3 = p.Ball_3_Average, ball4 = p.Ball_4_Average, ball5 = p.Ball_5_Average, megaball = p.MegaBall_Average}).ToList();
    List<power> viewPower = powerMean.Select(p => new power { ball1 = p.Ball_1_Average, ball2 = p.Ball_2_Average, ball3 = p.Ball_3_Average, ball4 = p.Ball_4_Average, ball5 = p.Ball_5_Average, powerball = p.Powerball_Average }).ToList();
    ViewBag.MegaList = viewMega;
    ViewBag.PowerList = viewPower;
