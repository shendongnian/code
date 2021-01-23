    public Expression BuildWhere(int org, int month, int year, Service service = null)
    {
        var datePartMethod =
            typeof(SqlFunctions)
                .GetMethod("DatePart",
                           new[]
                           {
                               typeof(string),
                               typeof(DateTime?)
                           });
        
        // Variable d
        var variable =
            Expression.Variable(typeof(SomeType));
        
        var orgConstant =
            Expression.Constant(org);
        // d.stuff_id
        var stuffId =
            Expression.Property(variable, "stuff_id");
        
        // d.stuff_id == org
        var stuffIdEquals =
            Expression.Equal(stuffId, orgConstant);
        
        // d.Date cast into Nullable DateTime
        var date =
            Expression.Convert(
                Expression.Property(variable, "Date"),
                typeof(DateTime?));
        
        var monthPartConstant =
            Expression.Constant("MONTH");
        // month cast to nullable int
        var monthConstant =
            Expression.Convert(
                Expression.Constant(month),
                typeof(int?));
        var yearPartConstant =
            Expression.Constant("YEAR");
        // year cast to nullable int
        var yearConstant =
            Expression.Convert(
                Expression.Constant(year),
                typeof(int?));
        
        // SqlFunctions.DatePart("MONTH", d.Date)
        var invokeDatePartMonthPart =
            Expression.Call(
                datePartMethod,
                monthPartConstant,
                date);
        // SqlFunctions.DatePart("YEAR", d.Date)
        var invokeDatePartYearPart =
            Expression.Call(
                datePartMethod,
                yearPartConstant,
                date);
        
        // SqlFunctions.DatePart("MONTH", d.Date) == month
        var dateMonthEquals =
            Expression.Equal(
                invokeDatePartMonthPart,
                monthConstant);
        
        // SqlFunctions.DatePart("MONTH", d.Date) == year
        var dateYearEquals =
            Expression.Equal(
                invokeDatePartYearPart,
                yearConstant);
        
        // d.Q1
        var q1 = Expression.Property(variable, "Q1");
        var nullConstant =
            Expression.Constant((int?) null);
        // d.Q1 != (int?) null
        var q1NotEquals =
            Expression.NotEqual(
                q1,
                nullConstant);
        
        // d.stuff_id == org
        // && SqlFunctions.DatePart("MONTH", d.Date) == month
        // && SqlFunctions.DatePart("YEAR", d.Date) == year
        // && d.Q1 != (int?) null
        var andExpression = 
            Expression.AndAlso(stuffIdEquals,
                Expression.AndAlso(dateMonthEquals,
                Expression.AndAlso(dateYearEquals,
                    q1NotEquals)));
        
        // Add d.Service only when not null
        if(service != null)
        {
            // d.Service
            var serviceConstant =
                Expression.Constant(service);
            var serviceProperty =
                Expression.Property(
                    variable,
                    "Service");
            
            // d.Service == service
            var serviceEquals =
                Expression.Equal(
                    serviceProperty,
                    serviceConstant);
            
            andExpression =
                Expression.AndAlso(
                    andExpression,
                    serviceEquals);
        }
        
        // Creates a lambda to represent the logic
        var parameter = Expression.Parameter(typeof(SomeType));
        return Expression
            .Lambda<Func<SomeType, bool>>(
                andExpression,
                parameter);
    }
