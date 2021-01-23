    var predicate = PredicateBuilder.True<MyClass>();
    //jobTerm
    if (!String.IsNullOrEmpty(vm.SelectedJobTerm))
        predicate = predicate.And(x => x.JobType.Name.Contains(vm.SelectedJobType));
    //jobType
    if (!String.IsNullOrEmpty(vm.SelectedJobType))
        predicate = predicate.And(x => x.JobType.Name.Contains(vm.SelectedJobType));
    predicate = predicate.Or(x => x.IsExternalPost);
    vacancies = vacancies.Where(predicate);
