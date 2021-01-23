    public JsonResult CreateNewMember(MembersModel m)
    {
        try
        {
            var newTblMember = new tblMember
                                     {
                                       Id = m.Id,
                                       FirstName = m.FirstName,
                                       LastName = m.LastName,
                                       // and so on for the other properties
                                      };
            using (var db = new DbEntityDataModel())
            {
                var EmpAdd = db.tblMembers.Add(newTblMember);  
                return Json(new { Result = "Error", Records = EmpAdd });
            }
        }
        catch (Exception EX)
        {
            return Json(new { Result = "Error", Message = EX });
        }
    }
