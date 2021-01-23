        //this is a utility static class
        public static class Utility{
        
        
        public static void fitFormToScreen(Form form, int h, int w)
        {
            //scale the form to the current screen resolution
            form.Height = (int)((float)form.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
            form.Width = (int)((float)form.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
            //here font is scaled like width
                form.Font = new Font(form.Font.FontFamily, form.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
            
            foreach (Control item in form.Controls)
            {
                fitControlsToScreen(item, h, w);
            }
        }
        static void fitControlsToScreen(Control cntrl, int h, int w)
        {
            if (Screen.PrimaryScreen.Bounds.Size.Height != h)
            {
                cntrl.Height = (int)((float)cntrl.Height * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                cntrl.Top = (int)((float)cntrl.Top * ((float)Screen.PrimaryScreen.Bounds.Size.Height / (float)h));
                
            }
            if (Screen.PrimaryScreen.Bounds.Size.Width != w)
            {
                cntrl.Width = (int)((float)cntrl.Width * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                cntrl.Left = (int)((float)cntrl.Left * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                
                    cntrl.Font = new Font(cntrl.Font.FontFamily, cntrl.Font.Size * ((float)Screen.PrimaryScreen.Bounds.Size.Width / (float)w));
                
            }
            
            foreach (Control item in cntrl.Controls)
            {
                fitControlsToScreen(item, h, w);
            }
        }
        }
            //inside form load event
            //send the width and height of the screen you designed the form for
            Utility.fitFormToScreen(this, 788, 1280);
            this.CenterToScreen();
