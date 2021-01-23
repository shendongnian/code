    var Person = (from a in DataBase.Persons
                  where a.Email == SIPerson.E_Mail
                  select new SigninPerson
                  {
                      Person_Id = a.Person_Id,
                      F_Name = a.First_Name,
                      L_Name = a.Last_Name,
                      E_Mail = a.Email,
                      Password = a.Password
                  })
                  .Take(1)
                  .AsEnumerable()
                  .Where(sp => sp.Password.Equals(SIPerson.Password));
