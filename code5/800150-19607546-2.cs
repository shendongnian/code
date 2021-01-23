    private void tbrNoOfPend_ValueChanged(object sender, EventArgs e)
    {
        tbrPend.Maximum = tbrNoOfPend.Value;
        if (tbrNoOfPend.Value < pendulums.Count)
        {
            pendulums.RemoveRange(tbrNoOfPend.Value, pendulums.Count - tbrNoOfPend.Value);
            return;
        }
        if (tbrNoOfPend.Value > pendulums.Count)
        {
            for (int i = pendulums.Count; i < tbrNoOfPend.Value; i++)
            {
                pendulums.Add(new Pendulum(this.Width + i * 40, this.ClientRectangle.Height, 0, 0, 0, 0, 0));
            }
        }
    }
