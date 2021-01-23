    public void PassColor(IColor c) {
        var newColor = null;
        newColor = c;
        PassColor(newColor); //The runtime will invoke the proper method based on the type
    }
    protected void PassColor(BlueColor c) {
        //Do Blue Stuff
    }
    protected void PassColor(GreenColor c) {
       //Do Green Stuff
    }
