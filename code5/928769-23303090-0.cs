     private void CreateTable(Button[] Tabla)
     {
         int horizotal = 45;
         int vertical = 45;
         for (int i = 0; i < Tabla.Length; i++)
         {
             Tabla[i] = new Button();
             Tabla[i].BackColor = Color.Azure;
             Tabla[i].Size = new Size(45, 45);
             Tabla[i].Location = new Point(horizotal, vertical);
              if ((i == 14) || (i == 29) || (i == 44) || (i == 59) || (i == 74) ||
                   (i == 89) || (i == 104) || (i == 119) || i == 134 || i == 149 || i == 164 || i == 179 || i == 194 || i == 209)
              {
                   vertical = 45;
                   horizotal = horizotal + 45;
              }
              else
                 vertical = vertical + 45;
              Tabla[i].MouseDown += new MouseEventHandler(button_down);//adding Down handler
              Tabla[i].MouseMove += new MouseEventHandler(button_move);//adding Move handler
              this.Controls.Add(Tabla[i]);
          }
    }
        private void button_down(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                starting.X = e.Location.X;
                starting.Y = e.Location.Y;
            }
        }
        private void button_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ((Button)sender).Left += e.Location.X - starting.X;
                ((Button)sender).Top += e.Location.Y - starting.Y;
            }
        }
