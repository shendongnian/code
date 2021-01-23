    pipeline.Commands.Add(invokeScript);
    Collection<PSObject> output = pipeline.Invoke();
    StringBuilder sb = new StringBuilder();
    foreach (PSObject psObject in output)
    {
        sb.AppendLine(psObject.ToString());
    }
