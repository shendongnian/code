    List<string> result = 
    test
    .Select 
    (
        t =>new 
        {
            Emails =  t.Split(new string[] { "----" }, StringSplitOptions.None)[0],
            LicensePlate = t.Split(new string[] { "----" }, StringSplitOptions.None)[1]
        }
    )
    .Select 
    (  
        t => new
        {
            Email = t.Emails.Split(';'),
            t.LicensePlate}
        )
    .SelectMany 
    ( 
        t => t.Email,
        (x,t)=>string.Concat(t,"----",x.LicensePlate)
    )
    .ToList();
