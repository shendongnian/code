    private void LoadSettings()
    {
        if (!System.IO.File.Exists(settingsPath))
        {
            try
            {
                System.IO.File.WriteAllText(settingsPath, "OSNAPS,0" + Environment.NewLine + "Mouse Value,0");
            }
            catch 
            {
                MessageBox.Show("MySettings.txt was unaccessable.  Contact the IT Department if you see this message.");
                return;
            }
        }
        string[] lines = System.IO.File.ReadAllLines(settingsPath);
        SetOsnaps(lines);
    }
    private void SetOsnaps(string[] lines)
    {
       try
       {
          // First line = lines[0]
          int val = Convert.ToInt32(lines[0].Split(',')[1]);
          if ((val & 1) == 1) { cbxEndpoint.Checked = true; }
          if ((val & 2) == 2) { cbxMidpoint.Checked = true; }
          if ((val & 4) == 4) { cbxCenter.Checked = true; }
          if ((val & 8) == 8) { cbxNode.Checked = true; }
          if ((val & 16) == 16) { cbxQuadrant.Checked = true; }
          if ((val & 32) == 32) { cbxIntersection.Checked = true; }
          if ((val & 64) == 64) { cbxInsertion.Checked = true; }
          if ((val & 128) == 128) { cbxPerpendicular.Checked = true; }
          if ((val & 256) == 256) { cbxTangent.Checked = true; }
          if ((val & 512) == 512) { cbxNearest.Checked = true; }
          if ((val & 2048) == 2048) { cbxApparent.Checked = true; }
          if ((val & 4096) == 4096) { cbxExtension.Checked = true; }
          if ((val & 8192) == 8192) { cbxParallel.Checked = true; }
          // Second line = lines[1]
          int mval = Convert.ToInt32(lines[1].Split(',')[1]);  
          if ((val & 1) == 1) { cbxRcDefault.Checked = true; }
          if ((val & 2) == 2) { cbxRcEdit.Checked = true; }
          if ((val & 4) == 4) { cbxRcCommandActive.Checked = true; }
          if ((val & 8) == 8) { cbxRcCommand.Checked = true; }
          if ((val & 16) == 16) { cbxRcMenu.Checked = true; }
     }
