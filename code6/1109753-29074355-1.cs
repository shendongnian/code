    public IEnumerable<CustomType> MyMethod()
    {
        return classAttendanceByCriteria.OrderBy(x => x.Lecture.Id)
           .GroupBy(x => new { x.Lecture, x.Teacher })
           .Select(x => new CustomType { Lecture = x.Key.Lecture, Teacher = x.Key.Teacher });
    }
