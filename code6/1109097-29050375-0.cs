    using System.Linq;
    ...
    if (!tableLayoutPanel1.Controls.OfType<UserControl>()
                          .Select(u => u.GetType())
                          .Any(t => t.Equals(userControl.GetType())))
