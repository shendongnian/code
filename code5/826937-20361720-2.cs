    var p = listPeople.SelectedItem as Dados.People;
    var vm = new PersonViewModel{Name = p.Name, Tel=p.Tel};
    var ep = new EditPeople(vm);
    if(ep.ShowDialog()){
        p.Name = vm.Name;
        p.Tel = vm.Tel;
        db.SaveChanges();
    }
