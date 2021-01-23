    var dataset1 = _v3Context.SQLPendingEvents
                             .Where(sp => sp.EventType.ToString() == str100w)
                             .AsEnumerable() // further processing occurs on client
                             .Select((sp,index) => new {
                                 ID = index + 1,
                                 sp.KeyDeviceID,
                                 sp.UpdateTime ,
                                 sp.EventClass ,
                                 sp.EventCode ,
                                 sp.EventType ,
                                 sp.EventDateTime ,
                                 sp.KeyPropertyID,
                                 sp.KeyEntityID,
                                 sp.EventText,
                                 sp.KeyUserID,
                                 sp.EventImage,
                                 sp.TaskType ,
                                 sp.TaskSubType ,
                                 sp.UniqueTaskID 
                             }).ToList();
