     public void startUpdateChecking()
        {
            UpdateHandler process = new UpdateHandler();
            process.initialize((s) => {changeText(s);});
        }
