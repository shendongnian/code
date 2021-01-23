    var result = 
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
        (x,t)=>new {Email = t,CarPlaket = x.LicensePlate)
    )
    .ToList();
    foreach(var email in result)
        Console.WriteLine("{0}---{1}",email.Email,email.CarPlaket;)
