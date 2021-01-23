    var vm = new PersonViewModel{Name = "name", Tel="tel"};
    var ep = new EditPeople(vm);
    if(ep.ShowDialog()){
        var p = new Dados.People();
        p.Name = vm.Name;
        p.Tel = vm.Tel;
        db.Peoples.Add(p);
        db.SaveChanges();
    }
