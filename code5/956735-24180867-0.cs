        GroupBox Group;
        TextBox cevapText;
        static int sayGB = 0;
        private void GroupBoxEkleme()
        {
            sayGB++;
            if (Group == null)
                Group = new GroupBox();
            else
            {
                Group.Dispose();
                Group = null;
                Group = new GroupBox();
            }
            Group.Name = "GroupBox" + sayGB.ToString();
            Group.Width = 1240;
            Group.Height = 595;
            Group.Text = "Soru & Cevap";
            Group.ForeColor = Color.Maroon;
            Group.Location = new Point(200, 86);
            
            if (cevapText == null)
                cevapText = new TextBox();
            else
            {
                cevapText.Dispose();
                cevapText = null;
                cevapText = new TextBox();
            }
            cevapText.Name = "cevapText" + sayGB.ToString();
            cevapText.Width = 1150;
            cevapText.Height = 490;
            cevapText.ForeColor = Color.Black;
            cevapText.Multiline = true;
            cevapText.Location = new Point(70, 67);
            //kontrolleri ekleme
            Group.Controls.Add(cevapText);
            this.Controls.Add(Group);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GroupBoxEkleme();
        }
