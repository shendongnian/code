    public static Column OR(this Column original, Column newc) {
        return (Column) ((int)original)| (((int) newc) << 3)
    }
    public static Column Get(this Column original) {
        // Some iterator that looks almost like the one you already have
    }
    public static Column GetOrder(this Column original) {
        // Some iterator that looks almost like the one you already have
    }
