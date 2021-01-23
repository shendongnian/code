     if (dto.personType == 1)
        {
            person = new Student() { .. };
        }
        else if (dto.personType == 2)
        {
            person = new Teacher() { .. };
           
        }
        else if (dto.personType == 3)
        {
            person = new Administrator() { .. };
        }
        person.Name = ""; // I believe these 3 properties will come from dto
        person.DOB = "";
        person.Address = "";
