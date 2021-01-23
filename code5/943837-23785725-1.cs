    var query = _data.UnitLogs.ToList().Select(c => new Unit
                  {
                      IdText = string.Format("ID:{0}",c.Id),
                      UserName = c.UserName
                  });
