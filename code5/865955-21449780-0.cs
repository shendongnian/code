    DateTime time = DateTime.Now;
    
    string newTime = time.ToShortTimeString();
    
    DateTime dt = new DateTime();
    DateTime.TryParse(newTime,out dt);
