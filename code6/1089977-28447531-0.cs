    private void Form1_Load(object sender, EventArgs e)
    {
        Random rnd = new Random();
        bool[] used = new bool[20];
        int number = 0;
        
        // if you have your buttons created in a container (groupbox for example)
        foreach (var btn in container.Controls)
        {
             number = rnd.Next(1, 20);
             while(used[number])
             {
                number = rnd.Next(1,20);
             }
             ((Button)btn).Tag = number.ToString();
             used[number] = true;
    
             if (number == 1 || number == 2)
             {
                Icon myIcon = (Icon)Resources.ResourceManager.GetObject(@"C:\Users\richa\Desktop\Goat.png");
                btn.Image = myIcon.ToBitmap();
              }
        }
       
    }
