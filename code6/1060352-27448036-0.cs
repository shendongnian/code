        using (var unitOfWork = new EFUnitOfWork())
        {
            var employee= GetAdminTypeAndPermission(loginInfo.UserID, unitOfWork); //DbContext passed in
            var permission = employee.AdminType.Permissions.FirstOrDefault();
        }
