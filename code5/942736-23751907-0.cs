        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = 10;
            count++; 
            
            for (int i = 1; i <= count; i++) 
            {
                var tb = new TextBox();
                mycanvas.Children.Add(tb); 
                tb.Name = "txtbox" + i; 
                tb.Width = 100; 
                Canvas.SetLeft(tb, 50); 
                Canvas.SetTop(tb, i * 20); 
                // My custom method
                MyMethod(i);
            }
        }
        private void MyMethod(int i)
        {
            // Do something with i
            Console.WriteLine(i);
        }
