    using (var context = new collegestudentsEntities1())
    {
        var StudentMarks = (from m in context.Marks
                            where m.StudIDFK == ID
                            select new[]
                            {
                                m.Marks1,
                                m.marks2,
                                m.Marks3,
                                m.Marks4
                            }).SelectMany(mark => mark).ToList();
    }
