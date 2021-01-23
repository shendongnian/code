    // just the last lines are different
    var query = session.QueryOver<CourseItem>()
        .JoinAlias(c => c.Teacher, () => teacherAlias)
        .Where(c => c.CourseID.IsInsensitiveLike(strNumber, option))
        .SelectList(list => list
               .Select(c => c.CourseID).WithAlias(() => courseAlias.CourseID)
               .Select(c => c.IsActive).WithAlias(() => courseAlias.IsActive)
               .Select(c => c.CourseDesc).WithAlias(() => courseAlias.CourseDesc)
               // the native WitAlias would not work, it uses expression
               // to extract just the last property
               //.Select(c => c.Teacher.ID).WithAlias(() => courseAlias.Teacher.ID)
               //.Select(c => c.Teacher.Name).WithAlias(() => courseAlias.Teacher.Name))
               // so we can use this way to pass the deep alias
              .Select(Projections.Property(() => teacherAlias.ID).As("Teacher.ID"))
              .Select(Projections.Property(() => teacherAlias.Name).As("Teacher.Name"))
               // instead of this
               // .TransformUsing(Transformers.AliasToBean<CourseItem>())
               // use this
               .TransformUsing(new DeepTransformer<CourseItem>())
       
