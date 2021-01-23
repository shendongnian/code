    public partial class Form1 : Form
        {
    	...
    
            Dictionary<int, UserControl1> NameOfUserControlInstance = new Dictionary<int, UserControl1>()
            {
                { 1, new UserControl1 {}},
                { 2, new UserControl1 {}},
                { 3, new UserControl1 {}}
            };
    
            private void Form1_Load(object sender, EventArgs e)
            {
    
                NameOfUserControlInstance[1].Location = new System.Drawing.Point(0, 0);
                NameOfUserControlInstance[2].Location = new System.Drawing.Point(200, 0);
                NameOfUserControlInstance[3].Location = new System.Drawing.Point(400, 0);
    
                Controls.Add(NameOfUserControlInstance[1]);
                Controls.Add(NameOfUserControlInstance[2]);
                Controls.Add(NameOfUserControlInstance[3]);
            }
    
            ...
    
        }  
