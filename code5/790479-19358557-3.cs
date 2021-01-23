    public void SomeMethod(string x, int y) {
        IDictionary<string, object> paramValues = Helper.TapInto(
            () => x, 
            () => y
        );
            
        // paramValues["x"] an paramValues["y"] will hold the values of x and y
    }
