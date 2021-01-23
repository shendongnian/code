    public static final int IAC = 255;
    ...
    void parseBuffer(byte[] bb, int len) {
        try {
            for(int i = 0; i < len; i++) {
                int value = bb[i] & 0xff; // To get a value in the range [0, 255]
                if (value == IAC) {
                    DoSomething();
                }
            }
        }
    }
