    public static bool SetupProxy(ref object proxy)
    {
        UsernameToken token = new UsernameToken(Var.sHTNGUsername, Var.sHTNGPassword, PasswordOption.SendPlainText);
        Policy clientPolicy = new ClientPolicy();
        clientPolicy.Assertions.Add(new UsernameOverTransportAssertion());
        proxy.GetType().InvokeMember("SetProxy", BindingFlags.InvokeMethod, null, proxy, new object[] { clientPolicy });
        proxy.GetType().InvokeMember("SetClientCredential", BindingFlags.InvokeMethod, null, proxy, new object[] { token });
        return true;
    }
