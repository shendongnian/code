    public void appBarIncreaseFont_Click(object sender, EventArgs e, PhoneApplicationPage page)
           {
            MainPage _page = page as MainPage;
            if (_page != null)
            {
                // example 1
                List<UIElement> buttons = _page.ContentPanel.Children.Where(x => x.GetType() == typeof(Button)).ToList();
                foreach (var x in buttons)
                {
                    Button button = x as Button;
                    if (button != null && button.FontSize < 21.5)
                        button.FontSize += 1;
                }
                // example 2
                if (_page.textBlock1.FontSize < 21.5)
                    _page.textBlock1.FontSize += 1;
            }
           } 
