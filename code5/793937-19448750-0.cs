    List<Button>Buttons=new List<Buttons>();
    
    private void button1_Click(object sender, EventArgs e)
    {
       Buttons.Clear();
       string a = textBox1.Text;
       //here should be checking if "a" is digit and is not empty
        int h = Convert.ToInt32(a);
    
        for (int i = 0; i <= h; i++)
        {
          Button btn=new Button();
          btn.Parent=panel1;
          btn.Size=new Size(60, 23);
          btn.Location = new Point(40,5+25*i); //arrange verically
          btn.Text = "Button "+i.ToString();
          btn.Click+=btn_Click;   
          btn.Tag="Some Value you want to restore after button click";
            
          Buttons.Add(btn)
        }
    }
