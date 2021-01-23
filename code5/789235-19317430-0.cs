    var newEntity = new KPITable();
    newEntity.Id = 55;
                    newEntity.Name = data.Name;
                    newEntity.Query = data.Query;
                    newEntity.TableName = data.TableName;
    _dbContext.KPIs.AddObject(newEntity);
    _dbContext.SaveChanges();
