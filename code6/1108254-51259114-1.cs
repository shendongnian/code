    private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control Control in this.HeaderPanel.Controls)
            {
                if (!(Control is Button)) //Change here depending on the Library you use for your contols
                {
                    Control.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
                }
            }
        }
