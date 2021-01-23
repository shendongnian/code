    /// <summary>
    /// Hash a password using the OpenBSD bcrypt scheme.
    /// </summary>
    /// <param name="password">The password to hash.</param>
    /// <param name="salt">The salt to hash with (perhaps generated
    /// using <c>BCrypt.GenerateSalt</c>).</param>
    /// <returns>The hashed password.</returns>
    public static string HashPassword(string password, string salt) {
        if (password == null) {
            throw new ArgumentNullException("password");
        }
        if (salt == null) {
            throw new ArgumentNullException("salt");
        }
        char minor = (char)0;
        if (salt[0] != '$' || salt[1] != '2') {
            throw new ArgumentException("Invalid salt version");
        }
        int offset;
        if (salt[1] != '$') {
            minor = salt[2];
            if (minor != 'a' || salt[3] != '$') {
                throw new ArgumentException("Invalid salt revision");
            }
            offset = 4;
        } else {
            offset = 3;
        }
        // Extract number of rounds
        if (salt[offset + 2] > '$') {
            throw new ArgumentException("Missing salt rounds");
        }
        int rounds = Int32.Parse(salt.Substring(offset, 2), NumberFormatInfo.InvariantInfo);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password + (minor >= 'a' ? "\0" : String.Empty));
        byte[] saltBytes = DecodeBase64(salt.Substring(offset + 3, 22),
                                        BCRYPT_SALT_LEN);
        BCrypt bcrypt = new BCrypt();
        byte[] hashed = bcrypt.CryptRaw(passwordBytes, saltBytes, rounds);
        StringBuilder rs = new StringBuilder();
        rs.Append("$2");
        if (minor >= 'a') {
            rs.Append(minor);
        }
        rs.Append('$');
        if (rounds < 10) {
            rs.Append('0');
        }
        rs.Append(rounds);
        rs.Append('$');
        rs.Append(EncodeBase64(saltBytes, saltBytes.Length));
        rs.Append(EncodeBase64(hashed,
                               (bf_crypt_ciphertext.Length * 4) - 1));
        return rs.ToString();
    }
