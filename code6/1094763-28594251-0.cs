    // Value coming from database
    Boolean? db_IsValid = null;
    // Option 1:
    // Check for null
    Boolean IsValid = db_IsValue.HasValue ? db_IsNull.Value : false;
    // Option 2:
    // Using GetValueOrDefault
    Boolean IsValid = db_IsValid.GetValueOrDefault(/*optional: false*/);
    // note above, without parameter, returns default(Boolean)
    // Option 3:
    // Syntactical sugar (producing same output as Option 1 or 2)
    Boolean IsValid = IsValid ?? false;
