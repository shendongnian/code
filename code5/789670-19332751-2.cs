    var panel = new FlowLayoutPanel();
    panel.SuspendLayout();
    panel.Size = new Size(600, 150);
    panel.Location = new Point(50, 50);
    panel.FlowDirection = FlowDirection.LeftToRight;
    panel.AutoScroll = true;
    panel.WrapContents = false;
    this.Controls.Add(panel);
    string cmdText = "SELECT (FirstName + ' ' + MiddleName + ' ' + LastName) as FullName, " +
                     "imgPath as ImagePath FROM TableVote WHERE Position='President'";
    using(SqlCommand com = new SqlCommand(cmdText,sc)){
       is(sc.State != ConnectionState.Open) sc.Open();
       SqlDataReader reader = com.ExecuteReader();       
       while(reader.Read()){
         AddRadioButton(reader.GetString(0), reader.GetString(1));
       }
       reader.Close();
       sc.Close();
    }
    panel.ResumeLayout(true);
    //...
    private void AddRadioButton(string fullName, string imagePath){
       RadioButton radio = new RadioButton {Text = fullName, Parent = panel};
       radio.Image = new Bitmap(Image.FromFile(imagePath),75,75);
       radio.TextImageRelation = TextImageRelation.ImageAboveText;       
    }
