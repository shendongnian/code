    [HttpPost]
    public bool UpdateUserPassword(MyComplexClass request)
    {
         MyEnum myenum = MyEnum.Val1; 
         if(Enum.Tryparse(request.Val,true, out myenum)
         {
              Log(myenum);
         }
         else
         {
              // invalid enum value POSTed
         }
    }
