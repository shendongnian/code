    var list = carInspectionRepository.GetAll().Select(x => new CarInspectionViewModel()
    {
        Id = x.Id,
        Description = x.Description,
        Agenda = new AgendaFiscalizacaoVM
        {
            Id = x.CarInspectionAgenda.Id,
            Name = x.CarInspectionAgenda.Name,
            DummyANameList = x.CarInspectionAgenda
                .DummyAList
                .Select(y => y.DummyB.Name)
                .ToList()
        }
    }).ToList(); 
