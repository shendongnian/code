    public void abStart()
        {
            try
            {
                AB ab = new AB(wb.getCookies(), side);
                this.Invoke((MethodInvoker)delegate
                {
                Application.Run(ab); //this is where the exception is thrown
                });
            }
            catch { }
        }
