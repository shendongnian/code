    public void DoWork<T>() {
        var thing = new T(); - runtime says "wtf are you doing? i cant create a 
                               new T because T might not have a public  
                               parameterless constructor"
    }
