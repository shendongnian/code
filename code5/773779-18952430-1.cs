    Renderer.ItemsSource = Enumerable.Range(0, 2000)
                .Select(t => new Item { Location = new Point(_rng.Next(800), _rng.Next(800)) }).ToArray();
    private void OnPointRequested(object sender, ItemPointEventArgs e)
    {
        var item = (Item) e.Item;
        item.Location = e.Point = new Point(item.Location.X + 1, item.Location.Y);
    }
