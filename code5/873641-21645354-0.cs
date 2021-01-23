    class Form1 : Form {
        private Button[] _textBoxes;
        
        private void button2_Click(object sender, EventArgs e) {
            int number = int.Parse(textBox3.Text);
            if(_textBoxes != null) {
                foreach(Button b in _textBoxes)
                    this.Controls.Remove(b);
            }
            
            _textBoxes = new Button[number];
            int location = 136;
    
            for (int i = 0; i < textBoxes.Length; i++) {
                location += 81;
                var txt = new Button();
                _textBoxes[i] = txt;
                txt.Name = "text" + i.ToString();
                txt.Text = "textBox" + i.ToString();
                txt.Location = new Point(location, 124);
                txt.Visible = true;
                this.Controls.Add(txt);
            }
        }
    }
