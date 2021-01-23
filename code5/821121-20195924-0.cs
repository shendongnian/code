    Model.TestEntities1 mda = new Model.TestEntities1();
    ObjectParameter userIdParameter = new ObjectParameter("UserId", userId);
    var test = mda.GetUserNameByUserId(userIdParameter );
         
    // ....
    
    public ObjectResult<ResType> GetUserNameByUserId(ObjectParameter userIdParameter)
    {
        return base.ExecuteFunction<ResType>("GetUserNameByUserId", userIdParameter);
    }
