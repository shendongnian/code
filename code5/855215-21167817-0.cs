    public class ListViewSorter : IComparer
            {
                public int ByColumn { get; set; }
                public int LastSort { get; set; }
                public int Compare(object o1, object o2)
                {
                    if (!(o1 is ListViewItem) || o1 is ListViewGroup)
                        return (0);
                    if (!(o2 is ListViewItem) || o2 is ListViewGroup)
                        return (0);
                    var itm = (ListViewItem)o1;
                    if (itm.Group.Header.Contains("Multi"))
                        return (0);
                    itm = (ListViewItem)o2;
                    if (itm.Group.Header.Contains("Multi"))
                        return (0);
                    var lvi1 = (ListViewItem)o2;
                    string str1 = "";
                    if (lvi1.SubItems.Count > ByColumn)
                        str1 = lvi1.SubItems[ByColumn].Text;
                    var lvi2 = (ListViewItem)o1;
                    string str2 = "";
                    if (lvi2.SubItems.Count > ByColumn)
                        str2 = lvi2.SubItems[ByColumn].Text;
                    int result;
                    string a, b;
                    if (lvi1.ListView.Sorting == SortOrder.Ascending)
                    {
                        a = str1;
                        b = str2;
                    }
                    else
                    {
                        a = str2;
                        b = str1;
                    }
                    DateTime dateTimeA;
                    DateTime dateTimeB;
                    double doubleA;
                    double doubleB;
                    if (DateTime.TryParse(a, out dateTimeA)
                      && DateTime.TryParse(b, out dateTimeB))
                    {
                        result = DateTime.Compare(dateTimeA, dateTimeB);
                    }
                    else
                    {
                        if (double.TryParse(a, out doubleA)
                          && double.TryParse(b, out doubleB))
                        {
                            result = doubleA.CompareTo(doubleB);
                        }
                        else
                        {
                            result = String.Compare(a, b);
                        }
                    }
                    LastSort = ByColumn;
                    return (result);
                }
            }
