        ToolTip tt = new ToolTip();
            button2.Enabled = false;
            if (!button2.Enabled)
            {
                tt.SetToolTip(this.button2, "");
            }
            else
            {
                tt.SetToolTip(this.button2, "Button2");
            }
            tt.SetToolTip(this.button1, "Button1");
