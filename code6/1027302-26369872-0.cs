    private void button4_Click(object sender, EventArgs e)
    {
        string Filename = img_path.Text;
    
        if (string.IsNullOrEmpty(Filename))
            return;
    
        if (Filename.ToCharArray().Intersect(Path.GetInvalidFileNameChars()).Any())
            return;
    
        File.Delete(Path.Combine(@"E:\Debug", Filename));
    }
