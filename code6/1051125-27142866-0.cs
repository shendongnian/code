    private void PopulateDropDownsOnViewModel(EmployeeSuperClass model)
    {
        model.FamilyDetailsFields = new FamilyList
        {
            employee_RelationTable = dt.GetRelations(),
            employee_BloodGroupTable = dt.GetBloodGroups(),
            employee_NationalityTable = dt.GetNationalities()
        }
     }
