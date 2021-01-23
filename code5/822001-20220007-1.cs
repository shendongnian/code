    var megaMean = _db.GetMegaMillionsMean();
    var powerMean = _db.GetPowerballMean();
    var vm = new PowerMega();
    vm.Megas = megaMean.Select(p => new mega {ball1 = p.Ball_1_Average, ball2 = p.Ball_2_Average, ball3 = p.Ball_3_Average, ball4 = p.Ball_4_Average, ball5 = p.Ball_5_Average, megaball = p.MegaBall_Average}).ToList();
    vm.Powers = powerMean.Select(p => new power { ball1 = p.Ball_1_Average, ball2 = p.Ball_2_Average, ball3 = p.Ball_3_Average, ball4 = p.Ball_4_Average, ball5 = p.Ball_5_Average, powerball = p.Powerball_Average }).ToList();
    
    
    return View(vm);
