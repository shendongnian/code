    class Child : Form
    {
        ....
        public string NewInfo { get; set; }
    }
    ....
    // code in the Parent
    var child = new ChildForm();
    if(child.ShowDialog() == DialogResult.OK)
    {
       this.UseChildData(child.NewInfo);
    }
