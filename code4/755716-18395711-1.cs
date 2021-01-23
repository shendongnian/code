     public RegisterModel GetRegisterUserById(int Id)
            {
                RegisterModel model = new RegisterModel();
                using (dataDataContext _context = new dataDataContext())
                {
                    return model = (from r in _context.Registrations
                                    where r.RID == Id
                                    select new RegisterModel
                                    {
    
                                        ID = Id,
                                        Name = r.REName,
                                        Address = r.REAddress,
                                        PhoneNo = r.REPhoneNo
                                    }).FirstOrDefault();
                }
            }
