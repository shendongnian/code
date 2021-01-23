        for (int i = 0; i <Count; i++)
        {
            var textBlock = new TextBlock();
            textBlock.Name = "txtblock" + i.ToString();
            textBlock.Text = "Dynamic Textblock " + i.ToString();
            var textBox = new TextBox();
            textBox.Name = "txtbox" + i.ToString();
            textBox.Text = "Dynamic Textblock " + i.ToString();
            GridName.Children.Add(textBlock);
            GridName.Children.Add(textBox);
        }
