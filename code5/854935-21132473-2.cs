       ToolTip tt = new ToolTip();
            tt.ShowAlways = false;
            button2.Enabled = false;
            if (button2.Enabled)
            {
                tt.SetToolTip(this.button2, "Button2");
            }
            else
            {
                tt.ShowAlways = false; 
            }
            tt.SetToolTip(this.button1, "Button1");
