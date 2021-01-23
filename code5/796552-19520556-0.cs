    MdiClient client = Controls.OfType<MdiClient>().First();
    client.Paint += (s, e) => {
       e.Graphics.DrawImage(Properties.Resources.bg, client.ClientRectangle);
    };
    //Set this to repaint when the size is changed
    typeof(Control).GetProperty("ResizeRedraw", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                  .SetValue(client, true, null);
    //set this to prevent flicker
    typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                   .SetValue(client, true, null);
