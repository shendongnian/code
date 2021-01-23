        using (vitaeEntities Db = new vitaeEntities())
        {
            return Db.Study.Where(st => st.Employee.ID_EMployee == EmpId) //empId => EmpId
                .ToList();
        }
    }
