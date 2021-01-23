            //fake TextBox...
            var textBox1 = new { Text = @"D:\Code\C#" };
            var directory = new DirectoryInfo(textBox1.Text);
            var items = SearchDirectory(directory);
            //you can print it to a console
            foreach (var item in items)
                Console.WriteLine(string.Concat(Enumerable.Repeat('\t', item.Deepth)) + item.Name);
            //or a textbox
            textBox1.Text = string.Join("\n", items.Select(i =>
                string.Concat(Enumerable.Repeat('\t', i.Deepth)) + i.Name));
            //or a table
            for (int i = 0; i < items.Count(); i++)
            {
                //with row = i, and column = items[i].Deepth + 1
            }
