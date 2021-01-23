    private void Form1_Load(object sender, EventArgs e)
    {
        names.Add( new NameDTO{ Id =2000, Name = "Ahemd"});
        names.Add(new NameDTO { Id = 5000, Name = "Omar" });
        names.Add(new NameDTO { Id = 4000, Name = "Mohamed" });
    
        comboBox1.DataSource = names;
        comboBox1.DisplayMember = "Name";
        comboBox1.ValueMember = "Id";
    }
    
