                private void Pos()
                {
                    for (; ; )
                    {
                        Thread.Sleep(10);
                        Point position = Cursor.Position;
    //You can use these to pass to your system tray or whereever you need it.
                        somePublicXVar = position.X; 
                        somePublicYVar = position.Y; 
                    }
                    
                }
                public void PointPosition()
                {
                    Thread pointThread = new Thread(new ThreadStart(Pos));
                    pointThread.Start();
                }
