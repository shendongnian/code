    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    namespace StackOverflowQuestion21361045
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            public class myClass
            {
                public string Code { get; set; }
                public string SortableCode
                {
                    get
                    {
                        return Regex.Replace(Code, @"^[^\d]+", string.Empty);
                    }
                }
            }
            private readonly SortableBindingList<myClass> objList = new SortableBindingList<myClass>();
            private void Form1_Load(object sender, EventArgs e)
            {
                objList.Add(new myClass {Code = "A23"});
                objList.Add(new myClass {Code = "B12"});
                objList.Add(new myClass {Code = "C04" });
                dataGridView1.DataSource = objList;
                dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            }
            private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                DataGridViewColumn newColumn = dataGridView1.Columns[e.ColumnIndex];
                DataGridViewColumn previouslySortedColumn = dataGridView1.SortedColumn;
                ListSortDirection direction;
                if (newColumn == dataGridView1.Columns[0])
                    newColumn = dataGridView1.Columns[1]; //if the user sorts by code, change the column so as to sort by SortableCode
                // If oldColumn is null, then the DataGridView is not sorted. 
                if (previouslySortedColumn != null)
                {
                    // Sort the same column again, reversing the SortOrder. 
                    if (previouslySortedColumn == newColumn &&
                        dataGridView1.SortOrder == SortOrder.Ascending)
                    {
                        direction = ListSortDirection.Descending;
                    }
                    else
                    {
                        // Sort a new column and remove the old SortGlyph.
                        direction = ListSortDirection.Ascending;
                        previouslySortedColumn.HeaderCell.SortGlyphDirection = SortOrder.None;
                    }
                }
                else
                {
                    direction = ListSortDirection.Ascending;
                }
                // Sort the selected column.
                dataGridView1.Sort(newColumn, direction);
                newColumn.HeaderCell.SortGlyphDirection =
                    direction == ListSortDirection.Ascending ?
                    SortOrder.Ascending : SortOrder.Descending;
            }
            private void dataGridView1_DataBindingComplete(object sender,
                DataGridViewBindingCompleteEventArgs e)
            {
                // Put each of the columns into programmatic sort mode. 
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.Programmatic;
                }
            }
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            #region Windows Form Designer generated code
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.dataGridView1 = new System.Windows.Forms.DataGridView();
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
                this.SuspendLayout();
                // 
                // dataGridView1
                // 
                this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
                this.dataGridView1.Location = new System.Drawing.Point(0, 0);
                this.dataGridView1.Name = "dataGridView1";
                this.dataGridView1.Size = new System.Drawing.Size(284, 261);
                this.dataGridView1.TabIndex = 0;
                this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
                this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 261);
                this.Controls.Add(this.dataGridView1);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
                this.ResumeLayout(false);
            }
            #endregion
            private System.Windows.Forms.DataGridView dataGridView1;
            public class SortableBindingList<T> : BindingList<T>
            {
                private ArrayList sortedList;
                private ArrayList unsortedItems;
                private bool isSortedValue;
                public SortableBindingList()
                {
                }
                public SortableBindingList(IList<T> list)
                {
                    foreach (object o in list)
                    {
                        this.Add((T)o);
                    }
                }
                protected override bool SupportsSearchingCore
                {
                    get
                    {
                        return true;
                    }
                }
                protected override int FindCore(PropertyDescriptor prop, object key)
                {
                    PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
                    T item;
                    if (key != null)
                    {
                        for (int i = 0; i < Count; ++i)
                        {
                            item = (T)Items[i];
                            if (propInfo.GetValue(item, null).Equals(key))
                                return i;
                        }
                    }
                    return -1;
                }
                public int Find(string property, object key)
                {
                    PropertyDescriptorCollection properties =
                        TypeDescriptor.GetProperties(typeof(T));
                    PropertyDescriptor prop = properties.Find(property, true);
                    if (prop == null)
                        return -1;
                    else
                        return FindCore(prop, key);
                }
                protected override bool SupportsSortingCore
                {
                    get { return true; }
                }
                protected override bool IsSortedCore
                {
                    get { return isSortedValue; }
                }
                ListSortDirection sortDirectionValue;
                PropertyDescriptor sortPropertyValue;
                protected override void ApplySortCore(PropertyDescriptor prop,
                    ListSortDirection direction)
                {
                    sortedList = new ArrayList();
                    Type interfaceType = prop.PropertyType.GetInterface("IComparable");
                    if (interfaceType == null && prop.PropertyType.IsValueType)
                    {
                        Type underlyingType = Nullable.GetUnderlyingType(prop.PropertyType);
                        if (underlyingType != null)
                        {
                            interfaceType = underlyingType.GetInterface("IComparable");
                        }
                    }
                    if (interfaceType != null)
                    {
                        sortPropertyValue = prop;
                        sortDirectionValue = direction;
                        IEnumerable<T> query = base.Items;
                        if (direction == ListSortDirection.Ascending)
                        {
                            query = query.OrderBy(i => prop.GetValue(i));
                        }
                        else
                        {
                            query = query.OrderByDescending(i => prop.GetValue(i));
                        }
                        int newIndex = 0;
                        foreach (object item in query)
                        {
                            this.Items[newIndex] = (T)item;
                            newIndex++;
                        }
                        isSortedValue = true;
                        this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                    }
                    else
                    {
                        throw new NotSupportedException("Cannot sort by " + prop.Name +
                            ". This" + prop.PropertyType.ToString() +
                            " does not implement IComparable");
                    }
                }
                protected override void RemoveSortCore()
                {
                    int position;
                    object temp;
                    if (unsortedItems != null)
                    {
                        for (int i = 0; i < unsortedItems.Count; )
                        {
                            position = this.Find("LastName",
                                unsortedItems[i].GetType().
                                GetProperty("LastName").GetValue(unsortedItems[i], null));
                            if (position > 0 && position != i)
                            {
                                temp = this[i];
                                this[i] = this[position];
                                this[position] = (T)temp;
                                i++;
                            }
                            else if (position == i)
                                i++;
                            else
                                unsortedItems.RemoveAt(i);
                        }
                        isSortedValue = false;
                        OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                    }
                }
                public void RemoveSort()
                {
                    RemoveSortCore();
                }
                protected override PropertyDescriptor SortPropertyCore
                {
                    get { return sortPropertyValue; }
                }
                protected override ListSortDirection SortDirectionCore
                {
                    get { return sortDirectionValue; }
                }
            } 
        }
    }
