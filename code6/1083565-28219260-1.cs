        [Test]
        public void SetListBox()
        {
            var listBox = new ListBox();
            var items = new List<string>{"one", "two", "three", "four"};
            listBox.SelectionMode = SelectionMode.MultiSimple;
            listBox.Items.AddRange(items.ToArray());
            var selectedItems = new List<string> {"two", "four"};
            selectedItems.Select(sd => listBox.Items.IndexOf(sd)).Where(i => i >= 0).ToList().ForEach(i => listBox.SetSelected(i, true));
            Assert.AreEqual(selectedItems, listBox.SelectedItems);
        }
