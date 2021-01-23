        using (var context = new TestContext())
    {
        context.Items.OfType<ItemWithContent>()
            .Where(o => string.IsNullOrWhiteSpace(o.Content)).Delete();
    }
