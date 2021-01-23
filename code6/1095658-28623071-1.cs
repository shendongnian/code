    public async Task PrintHeaderAsync(TextWriter output)
    {
        await output.WriteLineAsync(eInit + eCentre + "My Shop");
        await output.WriteLineAsync("Tel:0123 456 7890","");
        await output.WriteLineAsync("Web: www.ame.com");
        await output.WriteLineAsync("sales@ame.com");
        await output.WriteLineAsync("VAT Reg No:123 4567 89" + eLeft);
        await output.WriteLineAsync(new string('-', 20));
    }
