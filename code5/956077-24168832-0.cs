    public async Task<IBuffer> SampleProtectAsync(
        String strMsg,
        String strDescriptor,
        BinaryStringEncoding encoding)
    {
        // Create a DataProtectionProvider object for the specified descriptor.
        DataProtectionProvider Provider = new DataProtectionProvider(strDescriptor);
        // Encode the plaintext input message to a buffer.
        encoding = BinaryStringEncoding.Utf8;
        IBuffer buffMsg = CryptographicBuffer.ConvertStringToBinary(strMsg, encoding);
        // Encrypt the message.
        IBuffer buffProtected = await Provider.ProtectAsync(buffMsg);
        // Execution of the SampleProtectAsync function resumes here
        // after the awaited task (Provider.ProtectAsync) completes.
        return buffProtected;
    }
    public async Task<String> SampleUnprotectData(
        IBuffer buffProtected,
        BinaryStringEncoding encoding)
    {
        // Create a DataProtectionProvider object.
        DataProtectionProvider Provider = new DataProtectionProvider();
        // Decrypt the protected message specified on input.
        IBuffer buffUnprotected = await Provider.UnprotectAsync(buffProtected);
        // Execution of the SampleUnprotectData method resumes here
        // after the awaited task (Provider.UnprotectAsync) completes
        // Convert the unprotected message from an IBuffer object to a string.
        String strClearText = CryptographicBuffer.ConvertBinaryToString(encoding, buffUnprotected);
        // Return the plaintext string.
        return strClearText;
    }
