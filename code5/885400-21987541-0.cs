    for (int i = 0; i < 7; i++)
                {
                    TrackBar trackBar = new TrackBar();
                    trackBar.Tag = i;
                    // Other properties
                    trackBar.Scroll += new EventHandler(trackBar_Scroll);
                }
