    private void Form1_Resize(object sender, EventArgs e)
    {
        Control Container = this;
        Control ViewPort = textBox1;
        float ContainerRatio = 1f * Container.ClientRectangle.Width / Container.ClientRectangle.Height;
        const float TargetRatio_3_2 = 3f / 2f;
        const float TargetRatio_16_9 = 16f / 9f;
        const float TargetRatio_4_3 = 4f / 3f;
        const float TargetRatio_16_10 = 16f / 10f;
        //..
        float TargetRatio = TargetRatio_3_2;
        if (ContainerRatio < TargetRatio)
        {
            ViewPort.Width = Container.ClientRectangle.Width;
            ViewPort.Height = (int)(ViewPort.Width / TargetRatio);
            ViewPort.Top = (Container.ClientRectangle.Height - ViewPort.Height) / 2;
            ViewPort.Left = 0;
        }
        else
        {
            ViewPort.Height = Container.ClientRectangle.Height;
            ViewPort.Width = (int)(ViewPort.Height * TargetRatio);
            ViewPort.Top = 0;
            ViewPort.Left = (Container.ClientRectangle.Width - ViewPort.Width) / 2;
        }
    }
