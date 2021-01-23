    var tests = context.Tests.Include( "Exam" )
        .Select( t => new
        {
            Test = t,
            UserTests = t.UserTests.Where( ut => ut.UserId == studentId )
        } )
        .ToList();
