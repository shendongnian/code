    IEnumerable<DataAccessLayer.SQLPendingEventRecord> dataset1 = _v3Context.SQLPendingEvents
                         .Where(sp => sp.EventType.ToString() == str100w && sp.EventDateTime > dtStartDate && !**SQLFunctions.CharIndex(sp.KeyDeviceID,"~")>0)**
                         .AsEnumerable() // further processing occurs on client
                         .Select((sp, index) => new DataAccessLayer.SQLPendingEventRecord
                         {
                             ID = index + 1,
                             KeyDeviceID=sp.KeyDeviceID,
                             UpdateTime=sp.UpdateTime,
                             EventClass=sp.EventClass,
                             EventCode=sp.EventCode,
                             EventType=sp.EventType,
                             EventDateTime=Convert.ToDateTime(sp.EventDateTime),
                             KeyPropertyID=Convert.ToInt32 (sp.KeyPropertyID),
                             KeyEntityID=Convert.ToInt32 (sp.KeyEntityID),
                             EventText=sp.EventText,
                             KeyUserID=sp.KeyUserID,
                             //sp.EventImage,
                             TaskType=sp.TaskType,
                             TaskSubType=sp.TaskSubType,
                             UniqueTaskID=sp.UniqueTaskID
                         }).ToList();
