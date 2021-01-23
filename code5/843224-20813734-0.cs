    private void AddControlToPanel(Panel panel, Control ctrl)
        {
            if (panel.InvokeRequired)
            {
                panel.Invoke(new Action<Panel, Control>(AddControlToPanel), panel, ctrl);
                return;
            }
            else
            {
                panel.Controls.Add(ctrl);
            }
        }
