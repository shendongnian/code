    var query = session
      .QueryOver<EvaluationHead>(() => headAlias)
      .JoinQueryOver(() => headAlias.Employee, () => employeeAlias)
      // alias without EmployeeID
      .JoinQueryOver(() => headAlias.Manager, () => managerAlias)
      .JoinAlias(() => headAlias.Supervisor, () => supervisorAlias)
      // this is done via mapping
      //.Where(() => headAlias.SupervisorID == supervisorAlias.EmployeeID
      //                            && headAlias.ManagerID == managerAlias.EmployeeID)
      // .Where instead of And
      //.AndRestrictionOn(() => headAlias.KRAApprovedDate).IsNotNull
      .WhereRestrictionOn(() => headAlias.KRAApprovedDate).IsNotNull
      .SelectList(l => l
          .Select(h => h.EvaluationHeadID).WithAlias(() => dto.EvaluationHeadID)
          .Select(h => h.Employee.EmployeeID).WithAlias(() => dto.EmployeeID)
          .Select(h => employeeAlias.EmployeeFirstName).WithAlias(() => dto.EmployeeFirstName)
          .Select(h => employeeAlias.EmployeeMidName).WithAlias(() => dto.EmployeeMidName)
          .Select(h => employeeAlias.EmployeeLastName).WithAlias(() => dto.EmployeeLastName)
          .Select(h => h.EvaluationStartPeriod).WithAlias(() => dto.EvaluationStartPeriod)
          .Select(h => h.EvaluationEndPeriod).WithAlias(() => dto.EvaluationEndPeriod)
          .Select(h => h.ManagerID).WithAlias(() => dto.ManagerID)
          .Select(h => managerAlias.EmployeeFirstName).WithAlias(() => dto.ManagerFirstName)
          .Select(h => managerAlias.EmployeeLastName).WithAlias(() => dto.ManagerLastName)
          .Select(h => supervisorAlias.EmployeeFirstName).WithAlias(() => dto.SupervisorFirstName)
          .Select(h => supervisorAlias.EmployeeLastName).WithAlias(() => dto.SupervisorLastName)
          .Select(h => h.SupervisorID).WithAlias(() => dto.SupervisorID)
          .Select(h => h.DateCreated).WithAlias(() => dto.DateCreated))
      .TransformUsing(Transformers.AliasToBean(typeof(EvaluationHeadDTO)))
