    foreach (var userTest in userTests)
    {
        if (userTest.Test != null)
        {
            userTest.Test.UserTests = null;
            if (userTest.Test.Exam != null)
            {
                userTest.Test.Exam.Tests = null;
            }
        }
    }
