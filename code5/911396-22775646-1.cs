    return (from ea in context.View_1
            join vh in context.View_2 on (Int16)ea.EmpNo equals vh.EmpNo
            join rl in context.View_3 on ea.RoleID equals rl.id into outer_join
                from subjoin in outer_join where ea.GroupID == x
            group new
            {
                ea.EmpNo,
                subjoin.Role,
                vh.EmailAddress,
                vh.LNameByFName,
                ea.Active
            } by vh.LNameByFName into grp
            let item = grp.First()
            select new EmployeeWithEmail
            {
                EmpNum = item.EmpNo ?? 0,
                Role = item.Role,
                EmailAddress = item.EmailAddress,
                LNameByFname = item.LNameByFName,
                Active2 = item.Active ?? false
            }).ToList();
