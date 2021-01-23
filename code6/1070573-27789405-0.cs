    public OrigamiHttpResponse<List<ErrorRecords>> DoSmth(int param)
    {
        using (new OperationContextScope((IContextChannel)Proxy))
        {
            return Proxy.DoSmth(param);
        }
    }
