        var collection = database.GetCollection<Course>("Course");
        var course = collection.AsQueryable().First(c => c.Id == id);
        var mathLesson = course.Lessons.FirstOrDefault(l => l.Name == "Math");
        if (mathLesson != null)
        {
            mathLesson.Name = "AdvancedMath";
        }
        collection.Save(course);
