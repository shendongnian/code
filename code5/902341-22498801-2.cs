    private void btn1_Click(object sender, EventArgs e)
            {
                // On clicking the button the ExtractDatafromWebPage() method should be called with 5 threads at every 10 seconds.
                Timer t = new System.Threading.Timer(
                    () =>
                    {
                        for (int i = 1; i <= 5; i++)
                        {
                            //you can use thread pool thread
                            new Thread(() => this.ExtractDatafromWebPage()).Start();
                        }
                    }, null, 0, 10 * 1000);
            }
