        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int value;
            if (int.TryParse(this.textBox1.Text, out value))
            {
                var query =
                    from index in Enumerable.Range(0, 100)
                    from label in this.Controls
                        .OfType<Label>()
                        .Where(x => x.Name == "label" + (index + 1))
                    select new { label, index };
                foreach (var x in query)
                {
                    x.label.Text = (value + x.index).ToString();
                }
            }
        }
