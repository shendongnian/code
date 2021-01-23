    public ProvideData(byte[] buff) {
        for (int c = 0; c < 255; c++)
            buff[c] = (byte)c;
    }
    public void Fire() {
        if(DataReceived != null)
            DataReceived(this); // this implements `IProvideArray`
    }
