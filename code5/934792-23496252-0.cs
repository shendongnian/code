    protected override void OnMouseClick(MouseEventArgs e)
            {
                base.OnMouseClick(e);
                textBox1.Text = e.X.ToString();
                textBox2.Text = e.Y.ToString();
            }
    
           private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                textBox1.Text = e.X.ToString();
                textBox2.Text = e.Y.ToString();
               
            }
        } 
