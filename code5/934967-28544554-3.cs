    using (var context = new TestContext())
    {
        context.Items
            .Where(o => o is ItemWithContent && 
                string.IsNullOrWhiteSpace((o as ItemWithContent).Content)).Delete();
    }
