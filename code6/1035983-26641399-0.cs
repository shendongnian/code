        protected override void Seed(ITDAccountingContext context)
        {
            using (BillableUnitsContext existingDataContext = new BillableUnitsContext())
            {
                var newEmployeeRecords = new List<Employee>();
                foreach (var oldDbEmployee in existingDataContext.Employees.where(e=>MeetsYourSelectionCriteria(e)) 
                {
                    newEmployeeRecords.Add(
                        new Employee 
                        {
                            Name = oldDbEmployee.Name, 
                            Rank = oldDbEmployee.Rank, 
                            SerialNo=oldDbEmployee.SerialNo
                        });   
                }
                //similar stuff for departments
            }
            context.Employees.AddRange(newEmployeeRecords);
            context.SaveChanges();
        }
