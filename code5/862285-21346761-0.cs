    using (var context = new MyDBContext())
    {
        var school = context.Schools().FirstOrDefault(x => x.Name == schoolName);
    
        if (school == null)
        {
            // create new school
        }
        else
        {
            var classroom = new Classroom
            {
                School = school,
                // set other properties
            }
        }
    }
