     void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ContentControl cc = new ContentControl();
            Grid gr = new Grid();
            RichTextBox rtb = new RichTextBox();
            MainGrid.Children.Add(cc);
            cc.Content = gr;
            gr.Children.Add(rtb);
            FocusManager.SetFocusedElement(MainGrid, rtb);
        }
