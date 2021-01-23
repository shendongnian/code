    public partial class MainWindow : Window
    {
        string[] list = { "", "A", "B", "C", "D" };
        List<string> list1 = new List<string>() { "", "A", "B", "C", "D" };
        List<string> list2 = new List<string>() { "", "A", "B", "C", "D" };
        List<string> list3 = new List<string>() { "", "A", "B", "C", "D" };
        List<string> list4 = new List<string>() { "", "A", "B", "C", "D" };
        bool ListUpdating = false;
        public MainWindow()
        {
            InitializeComponent();
            foreach (string str in list)
            {
                Combo_1.Items.Add(str);
                Combo_2.Items.Add(str);
                Combo_3.Items.Add(str);
                Combo_4.Items.Add(str);
            }
        }
        private void Combo_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUpdating == false)
            {
                ListUpdating = true;
                string combo1 = Combo_1.SelectedItem.ToString();
                string combo2 = "";
                string combo3 = "";
                string combo4 = "";
                try
                {
                    combo2 = Combo_2.Text;
                }
                catch { }
                try
                {
                    combo3 = Combo_3.Text;
                }
                catch { }
                try
                {
                    combo4 = Combo_4.Text;
                }
                catch { }
                if (combo1 == "")
                {
                    for (int i = 0; i < list1.Count; i++)
                    {
                        if (!list2.Contains(list1[i]))
                        {
                            list2.Add(list1[i]);
                            Combo_2.Items.Clear();
                            list2.Sort();
                            for (int u = 0; u < list2.Count; u++)
                            {
                                Combo_2.Items.Add(list2[u]);
                                if (list2[u] == combo2)
                                    Combo_2.SelectedIndex = u;
                            }
                        }
                        if (!list3.Contains(list1[i]))
                        {
                            list3.Add(list1[i]);
                            Combo_3.Items.Clear();
                            list3.Sort();
                            for (int u = 0; u < list3.Count; u++)
                            {
                                Combo_3.Items.Add(list3[u]);
                                if (list3[u] == combo3)
                                    Combo_3.SelectedIndex = u;
                            }
                        }
                        if (!list4.Contains(list1[i]))
                        {
                            list4.Add(list1[i]);
                            Combo_4.Items.Clear();
                            list4.Sort();
                            for (int u = 0; u < list4.Count; u++)
                            {
                                Combo_4.Items.Add(list4[u]);
                                if (list4[u] == combo4)
                                    Combo_4.SelectedIndex = u;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Combo_2.Items.Count; i++)
                    {
                        if (combo1 == Combo_2.Items[i].ToString())
                        {
                            Combo_2.Items.RemoveAt(i);
                            list2.RemoveAt(i);
                            list2.Sort();
                            i = Combo_2.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_3.Items.Count; i++)
                    {
                        if (combo1 == Combo_3.Items[i].ToString())
                        {
                            Combo_3.Items.RemoveAt(i);
                            list3.RemoveAt(i);
                            list3.Sort();
                            i = Combo_3.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_4.Items.Count; i++)
                    {
                        if (combo1 == Combo_4.Items[i].ToString())
                        {
                            Combo_4.Items.RemoveAt(i);
                            list4.RemoveAt(i);
                            list4.Sort();
                            i = Combo_4.Items.Count;
                        }
                    }
                }
                ListUpdating = false;
            }
        }
        private void Combo_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUpdating == false)
            {
                ListUpdating = true;
                string combo1 = "";
                string combo2 = Combo_2.SelectedItem.ToString();
                string combo3 = "";
                string combo4 = "";
                try
                {
                    combo1 = Combo_1.Text;
                }
                catch { }
                try
                {
                    combo3 = Combo_3.Text;
                }
                catch { }
                try
                {
                    combo4 = Combo_4.Text;
                }
                catch { }
                if (combo2 == "")
                {
                    for (int i = 0; i < list2.Count; i++)
                    {
                        if (!list1.Contains(list2[i]))
                        {
                            list1.Add(list2[i]);
                            Combo_1.Items.Clear();
                            list1.Sort();
                            for (int u = 0; u < list1.Count; u++)
                            {
                                Combo_1.Items.Add(list2[u]);
                                if (list1[u] == combo1)
                                    Combo_1.SelectedIndex = u;
                            }
                        }
                        if (!list3.Contains(list2[i]))
                        {
                            list3.Add(list2[i]);
                            Combo_3.Items.Clear();
                            list3.Sort();
                            for (int u = 0; u < list3.Count; u++)
                            {
                                Combo_3.Items.Add(list3[u]);
                                if (list3[u] == combo3)
                                    Combo_3.SelectedIndex = u;
                            }
                        }
                        if (!list4.Contains(list2[i]))
                        {
                            list4.Add(list2[i]);
                            Combo_4.Items.Clear();
                            list4.Sort();
                            for (int u = 0; u < list4.Count; u++)
                            {
                                Combo_4.Items.Add(list4[u]);
                                if (list4[u] == combo4)
                                    Combo_4.SelectedIndex = u;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Combo_1.Items.Count; i++)
                    {
                        if (combo2 == Combo_1.Items[i].ToString())
                        {
                            Combo_1.Items.RemoveAt(i);
                            list1.RemoveAt(i);
                            list1.Sort();
                            i = Combo_1.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_3.Items.Count; i++)
                    {
                        if (combo2 == Combo_3.Items[i].ToString())
                        {
                            Combo_3.Items.RemoveAt(i);
                            list3.RemoveAt(i);
                            list3.Sort();
                            i = Combo_3.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_4.Items.Count; i++)
                    {
                        if (combo2 == Combo_4.Items[i].ToString())
                        {
                            Combo_4.Items.RemoveAt(i);
                            list4.RemoveAt(i);
                            list4.Sort();
                            i = Combo_4.Items.Count;
                        }
                    }
                }
                ListUpdating = false;
            }
        }
        private void Combo_3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUpdating == false)
            {
                ListUpdating = true;
                string combo1 = "";
                string combo2 = "";
                string combo3 = Combo_3.SelectedItem.ToString();
                string combo4 = "";
                try
                {
                    combo1 = Combo_1.Text;
                }
                catch { }
                try
                {
                    combo2 = Combo_2.Text;
                }
                catch { }
                try
                {
                    combo4 = Combo_4.Text;
                }
                catch { }
                if (combo3 == "")
                {
                    for (int i = 0; i < list3.Count; i++)
                    {
                        if (!list1.Contains(list3[i]))
                        {
                            list1.Add(list3[i]);
                            Combo_1.Items.Clear();
                            list1.Sort();
                            for (int u = 0; u < list1.Count; u++)
                            {
                                Combo_1.Items.Add(list1[u]);
                                if (list1[u] == combo1)
                                    Combo_1.SelectedIndex = u;
                            }
                        }
                        if (!list2.Contains(list3[i]))
                        {
                            list2.Add(list3[i]);
                            Combo_2.Items.Clear();
                            list2.Sort();
                            for (int u = 0; u < list2.Count; u++)
                            {
                                Combo_2.Items.Add(list2[u]);
                                if (list2[u] == combo2)
                                    Combo_2.SelectedIndex = u;
                            }
                        }
                        if (!list4.Contains(list3[i]))
                        {
                            list4.Add(list3[i]);
                            Combo_4.Items.Clear();
                            list4.Sort();
                            for (int u = 0; u < list4.Count; u++)
                            {
                                Combo_4.Items.Add(list4[u]);
                                if (list4[u] == combo4)
                                    Combo_4.SelectedIndex = u;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Combo_2.Items.Count; i++)
                    {
                        if (combo3 == Combo_2.Items[i].ToString())
                        {
                            Combo_2.Items.RemoveAt(i);
                            list2.RemoveAt(i);
                            i = Combo_2.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_1.Items.Count; i++)
                    {
                        if (combo3 == Combo_1.Items[i].ToString())
                        {
                            Combo_1.Items.RemoveAt(i);
                            list1.RemoveAt(i);
                            i = Combo_1.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_4.Items.Count; i++)
                    {
                        if (combo3 == Combo_4.Items[i].ToString())
                        {
                            Combo_4.Items.RemoveAt(i);
                            list4.RemoveAt(i);
                            i = Combo_4.Items.Count;
                        }
                    }
                }
                ListUpdating = false;
            }
        }
        private void Combo_4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListUpdating == false)
            {
                ListUpdating = true;
                string combo1 = "";
                string combo2 = "";
                string combo3 = "";
                string combo4 = Combo_4.SelectedItem.ToString();
                try
                {
                    combo1 = Combo_1.Text;
                }
                catch { }
                try
                {
                    combo2 = Combo_2.Text;
                }
                catch { }
                try
                {
                    combo3 = Combo_3.Text;
                }
                catch { }
                if (combo4 == "")
                {
                    for (int i = 0; i < list4.Count; i++)
                    {
                        if (!list1.Contains(list4[i]))
                        {
                            list1.Add(list4[i]);
                            Combo_1.Items.Clear();
                            list1.Sort();
                            for (int u = 0; u < list1.Count; u++)
                            {
                                Combo_1.Items.Add(list1[u]);
                                if (list1[u] == combo1)
                                    Combo_1.SelectedIndex = u;
                            }
                        }
                        if (!list2.Contains(list4[i]))
                        {
                            list2.Add(list4[i]);
                            Combo_2.Items.Clear();
                            list2.Sort();
                            for (int u = 0; u < list2.Count; u++)
                            {
                                Combo_2.Items.Add(list2[u]);
                                if (list2[u] == combo2)
                                    Combo_2.SelectedIndex = u;
                            }
                        }
                        if (!list3.Contains(list4[i]))
                        {
                            list3.Add(list4[i]);
                            Combo_3.Items.Clear();
                            list3.Sort();
                            for (int u = 0; u < list3.Count; u++)
                            {
                                Combo_3.Items.Add(list3[u]);
                                if (list3[u] == combo3)
                                    Combo_3.SelectedIndex = u;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Combo_2.Items.Count; i++)
                    {
                        if (combo4 == Combo_2.Items[i].ToString())
                        {
                            Combo_2.Items.RemoveAt(i);
                            list2.RemoveAt(i);
                            i = Combo_2.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_3.Items.Count; i++)
                    {
                        if (combo4 == Combo_3.Items[i].ToString())
                        {
                            Combo_3.Items.RemoveAt(i);
                            list3.RemoveAt(i);
                            i = Combo_3.Items.Count;
                        }
                    }
                    for (int i = 0; i < Combo_1.Items.Count; i++)
                    {
                        if (combo4 == Combo_1.Items[i].ToString())
                        {
                            Combo_1.Items.RemoveAt(i);
                            list1.RemoveAt(i);
                            i = Combo_1.Items.Count;
                        }
                    }
                }
                ListUpdating = false;
            }
        }
    }
