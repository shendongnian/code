    List<car> globalList = new List<car>();
        int globalCounter = 0;
        void Button1_Click(object sender, RoutedEventArgs e)
        {
            car c = new car();
            c.fav_car = textbox1.Text;
            c.user_id = globalCounter++;
            globalList.Add(c);
        }
        void Button2_Click(object sender, RoutedEventArgs e)
        {
            foreach (car c in globalList)
            {
                if (textbox2.text == c.user_id)
                {
                    textbox2.text == c.fav_car;
                }
            }
        }
