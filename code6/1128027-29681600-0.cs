    public bool EnrolOrUpdate(Student student)
        {
            using (var context = new StudentContext())
            {
                if (student.Id == 0)
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                    return true;
                }
    
                var tempStudent = context.Students.FirstOrDefault(x => x.Id == student.Id);
    
                // ReSharper disable once InvertIf
                if (tempStudent == null) return false;
                context.Students.Attach(tempStudent);
                tempStudent.Id = student.Id;
                tempStudent.Name = student.Name;
                tempStudent.BirthDate = student.BirthDate;
                tempStudent.Courses = student.Courses;
                Context.Entry(tempStudent).Collection(p => p.Students).Load();
                context.Entry(tempStudent).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
