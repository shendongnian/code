    // Method 2b
    if(obj is Child)
    {
        Child result2 = (Child)obj;
    }
    else
    {
        // Handle failed cast
    }
    
    // Method 3:
    Child result3 = obj as Child;
    if(result3 != null)
    {
        
    }
    else
    {
        // Handle failed cast
    }
