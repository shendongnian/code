            while (LDoor.Location.Y < MaxVal)
                while (Rdoor.Location.Y < MaxVal)
                {
                    LDoor.Location = new System.Drawing.Point(LDoor.Location.X, LDoor.Location.Y + 1);
                    System.Threading.Thread.Sleep(10);
                    Rdoor.Location = new System.Drawing.Point(Rdoor.Location.X, Rdoor.Location.Y + 1);
                    System.Threading.Thread.Sleep(10);
                }
