    List<string> lstResult = new List<string>();
    StringBuilder sb1 = new StringBuilder();
    StringBuilder sb2 = new StringBuilder();
    StringBuilder sb3 = new StringBuilder();
    foreach (String lol in Directory.GetFiles(@"mypath", "*.exe", SearchOption.AllDirectories);s)
    {    
        lstResult.Add(Path.GetFileNameWithoutExtension(lol) + "," + Path.GetExtension(lol)+"," + Path.GetFullPath(lol);
        
        sb1.AppendLine(lol);
        sb2.AppendLine(Path.GetFileNameWithoutExtension(lol));
        sb3.AppendLine(Path.GetExtension(lol));
    }
    
    File.WriteAllLines(@"C:\BigB.csv", lstResult.ToArray());
    
    textbox1.Text = sb1.ToString();
    textbox2.Text = sb2.ToString();
    textbox3.Text = sb3.ToString();
 
