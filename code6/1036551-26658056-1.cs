        public static void UnRegisterForShare()
        {
            startedSharing = false;
            DataTransferManager dataTransferManager = DataTransferManager.GetForCurrentView();
            dataTransferManager.DataRequested -= ShareTextHandler;
        }
