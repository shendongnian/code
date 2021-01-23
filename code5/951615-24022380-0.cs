    var toRemove = tabControls1
          .Controls
          .Cast<Control>()
          .Where(c => !(c.Name.Contains("panelRow") || c.Name.Contains("richTextBox") || c.Name.Contains("pictureBox")))
          .ToList();
    foreach(var c in toRemove)
    {
         tabControls1.Controls.Remove(c);
         ((IDisposable)c).Dispose();
    }
