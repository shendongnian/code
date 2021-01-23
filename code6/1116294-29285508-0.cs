    public long ToFileTime() {
        // Treats the input as local if it is not specified
        return ToUniversalTime().ToFileTimeUtc();
    }
 
    public long ToFileTimeUtc() {
        // Treats the input as universal if it is not specified
        long ticks = ((InternalKind & LocalMask) != 0) ? ToUniversalTime().InternalTicks : this.InternalTicks;
        ticks -= FileTimeOffset;
        if (ticks < 0) {
            throw new ArgumentOutOfRangeException(null, Environment.GetResourceString("ArgumentOutOfRange_FileTimeInvalid"));
        }
        return ticks;
    }
 
