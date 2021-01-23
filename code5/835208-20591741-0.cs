            while (!t)
            {
                max--;
                if (max <= 0)
                {
                    t = true;
                }
                Image maxS = Image.FromFile(@"C:\Users\MahchinLizard\Desktop\assets\tiles\" +max +".png");
                Application.DoEvents();
            }
