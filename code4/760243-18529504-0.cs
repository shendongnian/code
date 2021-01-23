     protected void btnCount_Click(object sender, EventArgs e)
      {
         string Str, Revstr = "";                
         str=(txtoriginal.Text);
           for (int i = Str.Length - 1; i >= 0; i--)
            {
                 Revstr = Revstr + Str[i];
            }
            lblAnswer.Text= Revstr;
      }
