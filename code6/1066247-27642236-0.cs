    static String toHex(byte[] ba) {
        StringBuilder hex = new StringBuilder(ba.length * 2);
        boolean skipZeroBytes = true;
        for (byte b : ba) {
            // As soon as we hit the first non-zero byte, we stop skipping bytes
            if (b != 0) {
                skipZeroBytes = false;
            }
            // If the current byte is zero, and we are in skipping mode, skip
            if (skipZeroBytes) {
                continue;
            }
            hex.append(String.format("%02X", b, 0xff));
        }
        if (skipZeroBytes) {
            // If we are still in skipping mode, it means all the bytes in the
            // array were zero and we skipped them all. So just return the
            // representation of a zero.
            return "00";
        } else {
            return hex.toString();
        }
    }
