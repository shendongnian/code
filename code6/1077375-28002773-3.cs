    foreach (Panel panel in Controls.OfType<Panel>())
    {
         foreach (var label in panel.Controls.OfType<Label>())
         {
             if (label.Text.Contains("label")) // or any other condition that you want to perform
             {
                 label.Visible = false;
             }
         }
    }
