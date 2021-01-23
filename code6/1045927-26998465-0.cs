    var salt = "FbSnXHPo12gb";
    var password = "geheim";
    var interactions = 12000;
    
    
    using (var hmac = new HMACSHA256())
    {
        var df = new Pbkdf2(hmac, password, salt, interactions);
        Console.WriteLine(Convert.ToBase64String(df.GetBytes(32)));
    }
    
    //hash I should get: 
    //pbkdf2_sha256$12000$FbSnXHPo12gb$LEpQrzPJXMI0m3tQuIE5mknqCv1GWgT5X2rWyLHN0Xk=
    
    //hash I get:
    //LEpQrzPJXMI0m3tQuIE5mknqCv1GWgT5X2rWyLHN0Xk=
