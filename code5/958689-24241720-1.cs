    code to bind data 
     
      List<MyData> list = new List<MyData>();
            for (int i = 0; i < 300; i++)
            {
                var data = new MyData();
                data.Question = "//yourquestion";
                data.Answer = "// your answer";
                data.ImageSource = new BitmapImage(new Uri("yourimagepat"));
            }
            myListBox.ItemsSource = list;
