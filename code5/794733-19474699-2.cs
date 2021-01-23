    private void Form2_Load(object sender, EventArgs e){
      panel1.Dock = panel2.Dock = DockStyle.Fill;
      panel1.Parent = panel2.Parent = this;//this refers to Form2
    }
    private void label4_Click(object sender, EventArgs e) {
      panel1.BringToFront();//show panel1
    }
    private void label5_Click(object sender, EventArgs e){
      panel2.BringToFront();//show panel2
    }
