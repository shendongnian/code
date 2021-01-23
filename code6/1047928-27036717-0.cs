    var vm = new ConsignorViewModel();
    var raised = 0;
    
    vm.PropertyChanged += (sender, e) => {
      if (e.PropertyName == "SearchTerm")
        ++raised;
      else
        Assert.Fail("Unexpected property name");
    }
    
    vm.SearchTerm = "42";
    Assert.That(raised, Is.EqualTo(1));
