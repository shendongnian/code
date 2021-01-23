    Dictionary<int, Pic> pics = new Dictionary<int, Pic>();
    
    public void doStuffWithImage(int picNumber) {
        // Check if instance called pic + picNumber exists
        if(!pics.ContainsKey(picNumber)) {
            // Create an instance
            pics[picNumber] = new Pic();
        }
    }
