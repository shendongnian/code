      private void RemoveOldLabels()
      {
        List<Label> LabelsToRemove = new List<Label>();
        foreach (var x in this.picNodes.Controls)
        {
            if (x.GetType() == typeof(System.Windows.Forms.Label))
            {
                LabelsToRemove.Add((Label)x);
            }
        }
        foreach (var label in LabelsToRemove)
        {
            this.picNodes.Controls.Remove(label);
            label.Dispose();
        }
      }
