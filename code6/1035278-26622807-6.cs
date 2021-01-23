    this.Hide();
    omg = new image(); 
    omg.Show();
    PrintFactory.sendTextToLPT1(s);
    omg.FormClosed += (object sender, EventArgs e) => { 
        File.Delete(Path.Combine(Application.StartupPath, Path.GetFileName(img_path.Text));
        this.Show();    
    };
