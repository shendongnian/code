    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Linq;
    namespace so
    {
        public class Program
        {
            public static void Main()
            {
                Application.EnableVisualStyles();
                Application.Run(new Form1());
            }
        }
        public class Form1 : Form
        {
            ListView lv;
            public Form1()
            {
                lv = new ListView 
                     { 
                        Parent = this, 
                        Dock = DockStyle.Fill, 
                        ShowGroups = true, 
                        View = View.Details
                     };
            }
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                var dic = new Dictionary<string, List<string>>()
                {
                    { "group 1", new[] { "sorry", "for having voted", "close for duplicate", "too fast" }.ToList() },
                    { "group 2", new[] { "this is not", "a gridview", "but the result", "looks like" }.ToList() },
                    { "group 3", new[] { "what you", "are trying", "to achieve" }.ToList() },
                    { "group 4", new[] { "hope", "it", "helps" }.ToList() }
                };
                lv.BeginUpdate();
                lv.Columns.Clear();
                lv.Columns.Add("Text");
                lv.Groups.Clear();
                lv.Groups.AddRange(
                    dic.Keys.Select(
                        s => new ListViewGroup(s, s)).ToArray());
                lv.Items.Clear();
                lv.Items.AddRange(
                    dic.SelectMany(kv => 
                        kv.Value.Select(item => 
                            new ListViewItem
                                { 
                                    Text = item,
                                    Group = lv.Groups[kv.Key]
                                })).ToArray());
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                lv.EndUpdate();
            }
        }
    }
