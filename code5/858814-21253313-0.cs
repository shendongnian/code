    var argb = Color.Red.ToArgb();
    var type = typeof(KnownColor).Assembly.GetType("System.Drawing.KnownColorTable");
    var field = type.GetField("colorTable",
                              BindingFlags.NonPublic | BindingFlags.Static);
    var colorTable = (int[]) field.GetValue(null);
    colorTable[(int) KnownColor.Control] = argb;
    new Form {Controls = {new Button {Text = "Success!"}}}.ShowDialog();
