        private IReadOnlyList<IPerson> GetPeopleData(int sex, int age)
        {
            if (sex > 30)
                return StudentRepository.GetStudent(sex, age).ToList();
            else
                return TeacherRepository.GetTeacher(sex, age).ToList();
        }
        …
        var result = GetPeopleData(sex, age);
        IQueryable<IPerson> rows = result2.AsQueryable();
