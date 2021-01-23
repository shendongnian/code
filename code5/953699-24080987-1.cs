    private void btn2_Click(object sender, EventArgs e)
    {
        i=1;
        x = rnd.Next(2);
        displaypics();
        if (pictureBoxs[i].Image == imageList1.Images[1])
        {
            num++;
        }
        if (num == 2)
        {
            tb1.Visible = true;
            tb1.Text = "GAME OVER!" + num;
        }
    }
