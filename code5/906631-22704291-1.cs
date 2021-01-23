    var userTest = _uow.UserTests
                .GetAll()
                .Where(t => t.UserId == "0" || t.UserId == userId)
                .First();
    
    var name = userTest.Test.Title;
