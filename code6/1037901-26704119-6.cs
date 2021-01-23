        public static void MoveListBoxItems(ListBox files1, ListBox files2)
        {
            var selections = files1.SelectedItems.Cast<FileAndPath>().ToList();
            foreach (var selection in selections)
            {
                files2.Items.Add(selection);
                files1.Items.Remove(selection);
            }
        }
