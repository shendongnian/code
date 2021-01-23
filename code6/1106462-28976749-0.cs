    public static bool MyTryParse(string value, out int result){
        int hold;
        if (int.TryParse(value, out hold)){
            result = hold;
            return true;
        }
    
        // Comment out the following line and you'll get a compile error
        result = default(int); // This method MUST set result
        return false;
    }
