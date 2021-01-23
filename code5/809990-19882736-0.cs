            private void button1_Click(object sender, EventArgs e)
            {
                List<Color> item = new List<Color>();
    
                item.Add(Color.blue);
                item.Add(Color.red);
                item.Add(Color.blue);
                item.Add(Color.red);
                item.Add(Color.red);
                item.Add(Color.green);
    
                List<Color> red = item.Where(x => x.Equals(Color.red)).ToList();
                List<Color> blue = item.Where(x => x.Equals(Color.blue)).ToList();
                List<Color> green = item.Where(x => x.Equals(Color.green)).ToList();
            }
            enum Color
            {
               red,
               blue,
               green
            }
