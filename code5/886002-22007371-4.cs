    private void Form2_Load(object sender, EventArgs e)
    {
        StreamWriter writer = new StreamWriter("Path_Of_The_File", false);
        writer.WriteLine(String.Format("{0},{1},{2}", "\"Time\"", "\"Big motor Actual Velocity\"", "\"Small Motor Actual Velocity\""));
        writer.close(); 
    }
