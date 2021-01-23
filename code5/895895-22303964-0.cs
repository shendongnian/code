    private object privateLock = new object();
    void update(){
        lock(privateLock)
        {
            //change state 
        }
    }
    valueclass createclone(){
        lock(privateLock)
        {
            //Clone 
        }
    }
