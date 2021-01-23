    var username= GetUniqueUserName();
    bool flag = true;
    while ( flag )
    {
         if(UtilityRepository.CheckUserName(username))
         {
              // next statement
              flag = false;
         }
         else
         {
              // recall CheckUser               
         }
    }
