You can use the GetValidationResult method:
    using (var context = new MyContext())
    {
        var myEntity = new MyEntity();
        
        var validationResult = context.Entry<MyEntity>(myEntity).GetValidationResult();
    }
