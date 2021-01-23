    public async Task<string> CheckSignUp(string username)
    {
        writer.WriteString("/F011/" + "\n");
        writer.WriteString(username + "\n");
        await writer.StoreAsync();
        await writer.FlushAsync();
        // ..rest of code...
    }
