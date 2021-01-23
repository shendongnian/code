        private IReadOnlyList<IPerson> GetPeopleData(int sex, int age)
        {
            if (sex > 30)
                return StudentRepository.GetStudent(sex, age).ToList();
            else
                return TeacherRepository.GetTeacher(sex, age).ToList();
        }
        …
        var result2 = StudentRepository.GetStudent(sex, age).ToList();
        IQueryable<IPerson> rows2 = result2.AsQueryable();
