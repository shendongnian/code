        int controlHeight = 0;
        foreach (CNewControl newControl in newControlList)
          {
            this.newControlsTab.Controls.Add(newControl );
            newControl.Dock = DockStyle.Top;
            newControl.Location = new System.Drawing.Point(40, 3 + controlHeight);
            controlHeight += newControl .Size.Height;
          }
