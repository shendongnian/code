     var ListValues = (from fDate in db.tblLog select fDate).Tolist(); 
    foreach (var item in ListValues)
            {
                DateTime in = Convert.ToDateTime(inDate );
                DateTime out = Convert.ToDateTime(outDate );
                TimeSpan ts = in - out;
                var duration = ts.TotalHours;
            }
