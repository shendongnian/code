    Employee employee = new Employee()
    {
        Section = new Section() { SectionName = "test" }
    };
    MemberExpression sectionMember = Expression.Property(ConstantExpression.Constant(employee), "Section");
    MemberExpression sectionNameMember = Expression.Property(sectionMember, "SectionName");
