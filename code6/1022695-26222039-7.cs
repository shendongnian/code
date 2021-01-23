       using Microsoft.Deployment.WindowsInstaller;
       private ExternalUIRecordHandler recordHandler;
       // ...
       IntPtr parent = IntPtr.Zero;
       recordHandler = RecordHandler;
       private MessageResult RecordHandler(InstallMessage messageType, Record messageRecord, MessageButtons buttons, MessageIcon icon, MessageDefaultButton defaultButton)
        {
            switch (messageType)
            {
                case InstallMessage.Info:
                    log.Info(message);
                    return MessageResult.OK;
                case InstallMessage.Initialize:
                    log.Debug(message);
                    return MessageResult.OK;
                case InstallMessage.ActionData:
                    log.Debug(message);
                    return MessageResult.OK;
                case InstallMessage.ActionStart:
                    log.Debug(message);
                    return MessageResult.OK;
                case InstallMessage.CommonData:
                    return MessageResult.OK;
                case InstallMessage.Error:
                    log.Error(message);
                    return MessageResult.OK;
                case InstallMessage.FatalExit:
                    log.Fatal(message);
                    return MessageResult.OK;
                case InstallMessage.FilesInUse:
                    return MessageResult.No;
                case InstallMessage.OutOfDiskSpace:
                    break;
                case InstallMessage.Progress:
                    return MessageResult.OK;
                case InstallMessage.ResolveSource:
                    return MessageResult.No;
                case InstallMessage.ShowDialog:
                    return MessageResult.OK;
                case InstallMessage.Terminate:
                    return MessageResult.OK;
                case InstallMessage.User:
                    return MessageResult.OK;
                case InstallMessage.Warning:
                    log.Warn(message);
                    return MessageResult.OK;
            }
            return MessageResult.No;
        }
