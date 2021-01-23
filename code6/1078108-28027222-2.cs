    using WinSCP;
    try
    {
        SessionOptions sessionOptions = new SessionOptions
        {
            Protocol = Protocol.Sftp,
            HostName = EdiConfiguration.FtpIpAddressOrHostName,
            UserName = EdiConfiguration.FtpUserName,
            Password = EdiConfiguration.FtpPassword,
            SshHostKeyFingerprint = EdiConfiguration.SshHostKeyFingerprint,
            PortNumber = EdiConfiguration.FtpPortNumber
        };
        using (Session session = new Session())
        {
            session.Open(sessionOptions);
            TransferOptions transferOptions = new TransferOptions();
            transferOptions.TransferMode = TransferMode.Binary;
            transferOptions.ResumeSupport.State = TransferResumeSupportState.Off;
            // Download the files in the OUT directory.
            TransferOperationResult transferOperationResult = session.GetFiles(EdiConfiguration.FtpDirectory, EdiConfiguration.IncommingFilePath, false, transferOptions);
            // Check and throw if there are any errors with the transfer operation.
            transferOperationResult.Check();
            // Remove files that have been downloaded.
            foreach (TransferEventArgs transfer in transferOperationResult.Transfers)
            {
                RemovalOperationResult removalResult = session.RemoveFiles(session.EscapeFileMask(transfer.FileName));
 
                if (!removalResult.IsSuccess)
                {
                    eventLogUtility.WriteToEventLog("There was an error removing the file: " + transfer.FileName + " from " + sessionOptions.HostName + ".", EventLogEntryType.Error);
                }
            }
        }
    }
    catch (SessionLocalException sle)
    {
        string errorDetail = "WinSCP: There was an error communicating with winscp process. winscp cannot be found or executed.";
        errorDetail += Environment.NewLine + "Message:" + sle.Message;
        errorDetail += Environment.NewLine + "Target Site:" + sle.TargetSite;
        errorDetail += Environment.NewLine + "Inner Exception:" + sle.InnerException;
        errorDetail += Environment.NewLine + "Stacktrace: " + sle.StackTrace;
        eventLogUtility.WriteToEventLog(errorDetail, EventLogEntryType.Error);
    }
    catch (SessionRemoteException sre)
    {
        string errorDetail = "WinSCP: Error is reported by the remote server; Local error occurs in WinSCP console session, such as error reading local file.";
        errorDetail += Environment.NewLine + "Message:" + sre.Message;
        errorDetail += Environment.NewLine + "Target Site:" + sre.TargetSite;
        errorDetail += Environment.NewLine + "Inner Exception:" + sre.InnerException;
        errorDetail += Environment.NewLine + "Stacktrace: " + sre.StackTrace;
        eventLogUtility.WriteToEventLog(errorDetail, EventLogEntryType.Error);
    }
    catch (Exception ex)
    {
        eventLogUtility.WriteToEventLog("Error in ProcessEdi() while downloading EDI files via FTP: Message:" + ex.Message + "Stacktrace: " + ex.StackTrace, EventLogEntryType.Error);
    }
