    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace bindinglist
    {
    public partial class Form1 : Form
    {
        myBindingList<myInt> bindingList;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bindingList = new myBindingList<myInt>();
            bindingList.Add(new myInt(8));
            bindingList.Add(new myInt(9));
            bindingList.Add(new myInt(11));
            bindingList.Add(new myInt(12));
            dataGridView1.DataSource = bindingList;
            bindingList.BeforeRemove += bindingList_BeforeRemove;
            bindingList.myIntOldNew += bindingList_myIntOldNew;
        }
        void bindingList_myIntOldNew(Form1.myInt oldItem, Form1.myInt newItem)
        {
            MessageBox.Show("You've just CHANGED item with value " + oldItem.myIntProp.ToString() + " to " + newItem.myIntProp.ToString());
        }
        void bindingList_BeforeRemove(Form1.myInt deletedItem)
        {
            MessageBox.Show("You've just deleted item with value " + deletedItem.myIntProp.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bindingList.Add(new myInt(13));
        }
        private void button3_Click(object sender, EventArgs e)
        {
            bindingList.RemoveAt(dataGridView1.SelectedRows[0].Index);
        }
        public class myInt : INotifyPropertyChanged
        {
            public myInt(int myIntVal)
            {
                myIntProp = myIntVal;
            }
            private int iMyInt;
            public int myIntProp {
                get
                {
                    return iMyInt;
                }
                set
                {
                    iMyInt = value;
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("myIntProp"));
                    }
                } 
            }
            public event PropertyChangedEventHandler PropertyChanged;
        }
        public class myBindingList<myInt> : BindingList<myInt>
        {
            protected override void SetItem(int index, myInt item)
            {
                myInt oldMyInt = this.Items[index];
                myInt newMyInt = item;
                if (myIntOldNew != null)
                {
                    myIntOldNew(oldMyInt, newMyInt);
                }
                base.SetItem(index, item);
            }
            
            protected override void RemoveItem(int itemIndex)
            {
                myInt deletedItem = this.Items[itemIndex];
                if (BeforeRemove != null)
                {
                    BeforeRemove(deletedItem);
                }
                base.RemoveItem(itemIndex);
            }
            public delegate void myIntDelegateChanged(myInt oldItem, myInt newItem);
            public event myIntDelegateChanged myIntOldNew;
            public delegate void myIntDelegate(myInt deletedItem);
            public event myIntDelegate BeforeRemove;
           
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bindingList[dataGridView1.SelectedRows[0].Index] = new myInt(new Random().Next());
        }
    }
    }
