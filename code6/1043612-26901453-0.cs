    // just the last line is different
    var query = session.QueryOver<CourseItem>()
        .JoinAlias(c => c.Teacher, () => teacherAlias)
        .Where(c => c.CourseID.IsInsensitiveLike(strNumber, option))
        .SelectList(list => list
               .Select(c => c.CourseID).WithAlias(() => courseAlias.CourseID)
               .Select(c => c.IsActive).WithAlias(() => courseAlias.IsActive)
               .Select(c => c.CourseDesc).WithAlias(() => courseAlias.CourseDesc)
               .Select(c => c.Teacher.ID).WithAlias(() => courseAlias.Teacher.ID)
               .Select(c => c.Teacher.Name).WithAlias(() => courseAlias.Teacher.Name))
               // instead of this
               // .TransformUsing(Transformers.AliasToBean<CourseItem>())
               // use this
               .TransformUsing(new DeepTransformer<CourseItem>())
       
