    private void InitializeItems()
            {
                for (int a = 0; a < File.ReadAllLines(@"bookmarks.txt").Count(); a++) //add already existing bookmarks
                {
                    index = Array.FindIndex(bookmarks, i => i == null || i.Length == 0); //find closest empty spot in array
                    bookmarks[index] = getbook[a];
                    Button button = new Button();
                    book[index] = button;
                    book[index].Height = 31;
                    book[index].Content = bookmarks[index];
                    book[index].Click += Button_Click;
                    Bookbar.Items.Add(book[index]);
    
                    button.MouseRightButtonDown += button_MouseRightButtonDown;
    
                }
                
            }
    
            void button_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
            {
                Button button = sender as Button;
                ContextMenu menu = new ContextMenu();
                menu.Items.Add(new MenuItem() { Header = "Delete" });
    
                button.ContextMenu = menu;
    
            }
