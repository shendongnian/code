    this.customListView = new CustomListView
                            {
                                Dock = DockStyle.Fill,
                                Parent = this
                            };
    this.customListView.BeginUpdate();
    for (int i = 0; i < 6; i++)
    {
        var item = new BetterListViewItem
                    {
                        Image = imageGraph,
                        Text = String.Format("Item no. {0}", i)
                    };
        this.customListView.Items.Add(item);
    }
    var group1 = new BetterListViewGroup("First group");
    var group2 = new BetterListViewGroup("Second group");
    var group3 = new BetterListViewGroup("Third group");
    this.customListView.Groups.AddRange(new[] { group1, group2, group3 });
    this.customListView.Items[0].Group = group1;
    this.customListView.Items[1].Group = group1;
    this.customListView.Items[2].Group = group2;
    this.customListView.Items[3].Group = group2;
    this.customListView.Items[4].Group = group2;
    this.customListView.Items[5].Group = group3;
    this.customListView.AutoSizeItemsInDetailsView = true;
    this.customListView.GroupHeaderBehavior = BetterListViewGroupHeaderBehavior.None;
    this.customListView.ShowGroups = true;
    this.customListView.LayoutItemsCurrent.ElementOuterPadding = new Size(0, 8);
    this.customListView.EndUpdate();
