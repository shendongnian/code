    var result = new List<CaseViewModel>();
    var cases = _casesRepository.All;
    foreach (var customCase in cases) {
        result.Add(new CaseViewModel() {
            Complete = customCase.IsComplete(), // <- at this point, the customCase is
                                                // the derived implementation
                                                // but the full hierarchy is missing
        });
    }
