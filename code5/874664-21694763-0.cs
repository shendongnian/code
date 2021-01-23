     private string GetUserName(int SessionId)
            {
                try
                {
                    Runspace runspace = RunspaceFactory.CreateRunspace();
                    runspace.Open();
    
                    Pipeline pipeline = runspace.CreatePipeline();
                    pipeline.Commands.AddScript("Quser");
                    pipeline.Commands.Add("Out-String");
    
                    Collection<PSObject> results = pipeline.Invoke();
    
                    runspace.Close();
    
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (PSObject obj in results)
                    {
                        stringBuilder.AppendLine(obj.ToString());
                    }
    
                    foreach (string User in stringBuilder.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1))
                    {
                        string[] UserAttributes = User.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries);
                        if (int.Parse(UserAttributes[2].Trim()) == SessionId)
                        {
                            return UserAttributes[0].Replace(">", string.Empty).Trim();
                        }
                    }
    
                    return stringBuilder.ToString();
                }
                catch (Exception ex)
                {
                }
    
                return string.Empty;
            }
