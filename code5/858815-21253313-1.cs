    var argb = Color.Blue.ToArgb();
    var type = typeof (Color).Assembly.GetType("System.Drawing.KnownColorTable");
    var field = type.GetField("colorTable",
                              BindingFlags.NonPublic | BindingFlags.Static);
    var colorTable = (int[]) field.GetValue(null);
    colorTable[(int) KnownColor.Control] = argb;
    colorTable[(int) KnownColor.ControlText] = Color.Red.ToArgb();
    new Form {Controls = {new Button {Text = "Success!"}}}.ShowDialog();
