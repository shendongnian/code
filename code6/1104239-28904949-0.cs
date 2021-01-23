    private void button1_Click(object sender, EventArgs e){
         string[] lines = System.IO.File.ReadAllLines(@"D:\C#\test.txt");
         String username = lines[0];
         String password = lines[1];
    }
