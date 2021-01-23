    string[] criteria = searchCriteria.Split('_');
    var columnName = criteria[0];                        
    var columnValue = criteria[1];
    
    var eParam = Expression.Parameter(typeof(EmployeeDetail), "e");
    var comparison = Expression.Equal(Expression.Property(eParam, columnName), Expression.Convert(Expression.Constant(columnValue), Expression.Property(eParam, columnName).Type));
    
    var lambda = Expression.Lambda<Func<EmployeeDetail, bool>>(comparison, eParam);
    
    var subQry = (from e in ctx.tblEmployee
                  where (e.DateOfJoining <= startDate || (e.DateOfJoining.Value.Month == ApplyMonth && e.DateOfJoining.Value.Year == ApplyYear)) &&
                        monInputEmployee.Contains(e.Id) == flag
                  select new
                  {
                      e.Id,
                      e.Code,
                      e.FName,
                      e.DateOfJoining
                  }).Where(lambda)
                    .ToList();
