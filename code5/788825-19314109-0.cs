        public async Task _connect(string token, string idInstalation, string lang)
        {
            ...
        }
    
        public static Task connect(string token, string idInstalation, string lang)
        {
            await instance._connect(token,idInstalation,lang);
        }
