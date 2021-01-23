        if(searchCriteria.Age.HasValue){
            if(searchCriteria.Age != -1)
                employees = employees.Where(e => e.Age == searchCriteria.Age.Value);
            }
            else{
                employees = employees.Where(e => e.Age == null);
        }
    }
