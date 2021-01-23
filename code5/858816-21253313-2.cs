    var type = typeof (Color).Assembly.GetType("System.Drawing.KnownColorTable");
    var field = type.GetField("colorTable",
                              BindingFlags.NonPublic | BindingFlags.Static);
    var colorTable = (int[]) field.GetValue(null);
    colorTable[(int) KnownColor.Control] = Color.Blue.ToArgb();
    colorTable[(int) KnownColor.ControlText] = Color.Red.ToArgb();
    new Form {Controls = {new Button {Text = "Success!"}}}.ShowDialog();
