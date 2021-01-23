    List<string> newData = new List<string>();
    ...
    
    private void buttonSave_Click(object sender, EventArgs e) {
      newData.Add (textBoxLatitude.Text);
      newData.Add (textBoxLongtitude.Text);
      newData.Add (textBoxElevation.Text);
      ...
    
    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      TextWriter tw = new StreamWriter("NewData.txt");                       
      tw.WriteLine(String.Join(", ", newData));
      ...
