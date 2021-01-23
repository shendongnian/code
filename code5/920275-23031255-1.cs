    if (ModelState.IsValid)
    {
        var m1 = db.M1.Include(m => m.M2s).FirstOrDefault(x => x.M1Id == M1Vm.M1Id);
        db.Entry(m1).CurrentValues.SetValues(M1Vm);
        UpdateM2(m1, M1Vm.NewM2s);
        db.SaveChanges();
    }
