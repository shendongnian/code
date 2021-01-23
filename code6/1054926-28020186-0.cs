    string exchangePowershellRPSURI = "http://my.domain/powershell?serializationLevel=Full";
        PSCredential credentials = (PSCredential)null;
        //Provides the connection information that is needed to connect to a remote runspace
        // Prepare the connection           
        WSManConnectionInfo connInfo = new WSManConnectionInfo((new Uri(exchangePowershellRPSURI)),
            "http://schemas.microsoft.com/powershell/Microsoft.Exchange", credentials);
        connInfo.AuthenticationMechanism = AuthenticationMechanism.Kerberos; 
        connInfo.SkipCACheck = true;
        connInfo.SkipCNCheck = true;
        connInfo.SkipRevocationCheck = true;
        // Create the runspace where the command will be executed           
        Runspace runspace = RunspaceFactory.CreateRunspace(connInfo);
        // Add the command to the runspace's pipeline           
            runspace.Open();
            try
                    {
                        Command enableUMMB = new Command("Enable-UMMailbox");
                        enableUMMB.Parameters.Add("Identity", UserPrincipalName);
                        enableUMMB.Parameters.Add("PinExpired", false);
                        enableUMMB.Parameters.Add("UMMailboxPolicy", "UM2 Default Policy");
                        Pipeline enableUMMailboxPipiLine = runspace.CreatePipeline();
                        enableUMMailboxPipiLine.Commands.Add(enableUMMB);
                        enableUMMailboxPipiLine.Invoke();
                    }
                    catch (ApplicationException e)
                    {
                        MessageBox.Show("Unable to connect to UMMailbox.\n Error:\n" + e.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
