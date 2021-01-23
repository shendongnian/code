    var observable = Observable.FromEventPattern<MouseEventArgs>(this, "MouseMove")
                                       .Select((eventPattern, count) => new {eventPattern.EventArgs, Count = count})
                                       .WithPrevious((previous, current) =>
                                           {
                                               var currentPoint = current == null
                                                                      ? new Point(0, 0)
                                                                      : current.EventArgs.Location;
                                               var previousPoint = previous == null
                                                                       ? new Point(0, 0)
                                                                       : previous.EventArgs.Location;
                                               return
                                                   new
                                                       {
                                                           CurrentPoint = currentPoint,
                                                           PreviousPoint = previousPoint,
                                                           Count = current == null ? 0 : current.Count
                                                       };
                                           })
                                       .Subscribe(a =>
                                           {
                                               label2.Text =
                                                   String.Format(
                                                       "Curr X: {0} * Y: {1} |||| Prev X: {2} * Prev Y: {3} - Count = {4}",
                                                       a.CurrentPoint.X, a.CurrentPoint.Y,
                                                       a.PreviousPoint.X, a.PreviousPoint.Y,
                                                       a.Count);
                                               label1.Text = String.Format("X: {0} ** Y: {1}",
                                                                           a.CurrentPoint.X.CompareTo(
                                                                               a.PreviousPoint.X),
                                                                           a.CurrentPoint.Y.CompareTo(
                                                                               a.PreviousPoint.Y));
                                               var listItem = new ListViewItem(a.Count.ToString());
                                               listItem.SubItems.Add(a.CurrentPoint.X.ToString());
                                               listItem.SubItems.Add(a.CurrentPoint.Y.ToString());
                                               listView1.Items.Add(listItem);
                                               listView1.EnsureVisible(listView1.Items.Count - 1);
                                           });
