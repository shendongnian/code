        foreach (var x in myCollection)
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        //Do something
                    }
                }
                catch (Exception ex)
                {
                    //Do something
                }
            });
        }
