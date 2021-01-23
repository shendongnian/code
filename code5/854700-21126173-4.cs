       private void button1_Click(object sender, EventArgs e)
       {
            int l;
            int w;
            int h;
            int paint;
            int answer;
            l = int.Parse(LengthtextBox.Text);
            w = int.Parse(WidthtextBox.Text);
            h = int.Parse(HeighttextBox.Text);
            paint = 350;
            answer = (l * w * h) / paint;
             MessageBox.Show( answer.ToString() );
        }
