        void Writer()
        {
            foreach (SaveTask t in queue.GetConsumingEnumerable())
            {
                try
                {
                    SaveBitmap(t.fname, t.bm);
                }
                catch (Exception e)
                {
                    //comes here after called Stop
                    return;
                }
            }
        }
