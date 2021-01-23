    foreach (UIElement x in ElementsAtPoint)
    {
        f = x as FrameworkElement;
        if (f is Path)
        {
            try { 
            h = f as Path;
            Storyboard sb = h.Resources["StoryBoard1"] as Storyboard;
            sb.Begin();
                }
            catch
            {
            }
            break;
        }
    }
