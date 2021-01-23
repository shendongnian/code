    private void Load()
        {
            if (onLoad != null)
            {
                loading = true;
                while (true)
                {
                    loading = onLoad(this, EventArgs.Empty);
                    if (!loading)
                        break;
                    Thread.Sleep(1); 
                }
            }
        }
    
