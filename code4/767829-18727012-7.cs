    private void button1_Click(object sender, EventArgs e)
    {
          string p=TextBox1.Text;
          string d=TextBox2.Text;
          string w=TextBox3.Text;
          string t=TextBox4.Text;
          string params = String.Format("{0} {1} {2} {3}",p,d,w,t);
          System.Diagnostics.Process.Start("SamplePlot.exe", params);
    }
