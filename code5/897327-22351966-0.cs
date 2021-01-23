      using System;
      using System.Collections.Generic;
      using System.Linq;
      using System.Windows.Forms;
      namespace WindowsFormsApplication1 {
         public partial class Form1 : Form {
            public class Selection {
               public enum eType { None, Indian, Chinese, Italian, British };
               public eType Type { get; private set; }
               public string Name { get; private set; }
               public Selection(eType xType, string xName) {
                  Type = xType;
                  Name = xName;
               } //
            } // class
            private List<Selection> _AllMeals = new List<Selection>();
            public Form1() {
               InitializeComponent();
               comboBox1.DataSource = Enum.GetValues(typeof(Selection.eType)).Cast<Selection.eType>();
               comboBox1.SelectedItem = Selection.eType.None;
               Selection s1 = new Selection(Selection.eType.Chinese, "tasty Wan Tan soup");
               Selection s2 = new Selection(Selection.eType.Chinese, "yummy Spring Rolls");
               Selection s3 = new Selection(Selection.eType.Indian, "extreme spicy");
               Selection s4 = new Selection(Selection.eType.Indian, "deadly spicy");
               Selection s5 = new Selection(Selection.eType.Italian, "great Tortellini");
               Selection s6 = new Selection(Selection.eType.Italian, "large Pizza");
               Selection s7 = new Selection(Selection.eType.British, "fatty Fish and Chips");
               _AllMeals.AddRange(new Selection[] { s1, s2, s3, s4, s5, s6 });
               dataGridView1.DataSource = _AllMeals;
            } //
            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
               object o = comboBox1.SelectedItem;
               Selection.eType lFilter = (Selection.eType)o;
               var lOptions = (from x in _AllMeals
                               where x.Type == lFilter
                               select x).ToArray();
               dataGridView1.AutoGenerateColumns = true;
               dataGridView1.DataSource = lOptions;
               dataGridView1.Invalidate();
            } //
         } // class
      } // namespace
