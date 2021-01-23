    private byte storage;
    public bool Property1 {
        get {
            return (storage & 0x01) != 0;
        }
        set {
            if (value) {
                storage |= 0x01;
            } else {
                storage &= ~0x01;
            }
        }
    }
    public bool Property2 {
        get {
            return (storage & 0x02) != 0;
        }
        set {
            if (value) {
                storage |= 0x02;
            } else {
                storage &= ~0x02;
            }
        }
    }
    public bool Property3 {
        get {
            return (storage & 0x04) != 0;
        }
        set {
            if (value) {
                storage |= 0x04;
            } else {
                storage &= ~0x04;
            }
        }
    }
