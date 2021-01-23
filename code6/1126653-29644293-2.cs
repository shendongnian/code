    class Plugin:APlugin
        {
            public override void DoWork()
            {
                // in here, the third party programmer can write anything
                // for example: update data in database
                UpdateData();
            }
            private void UpdateData()
            {
                // do update data
            }
        }
