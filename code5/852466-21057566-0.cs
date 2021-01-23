    double ticks = Math.Floor(objRemarkData.Date.ToUniversalTime() 
            .Subtract(new DateTime(1970, 1, 1))      
            .TotalMilliseconds); 
    var newob = new { Date =ticks, Remark = objRemarkData.Remark};
	JS.GetJSON(newob);
