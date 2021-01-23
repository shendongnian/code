     [HttpGet]
     public bool IsCodeValid(string code)
     {
         return new {isValid: db.Usagers.Any(u => u.CodeAcces == code)};
     }
