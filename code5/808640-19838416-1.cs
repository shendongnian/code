    public class ListViewItemID : ListViewItem
    {
        public int ID { get; set; }
    }
    public class CheckBoxID : CheckBox
    {
        public int ID { get; set; }
    }
    public class program
    {
        void Main()
        {
            var itemOne = new ListViewItemID { ID = 1 };
            var itemTwo = new ListViewItemID { ID = 2 };
            var checkBoxOne = new CheckBoxID { ID = itemOne.ID };
            checkBoxOne.CheckedChanged += HideCheckBox;
            var checkBoxTwo = new CheckBoxID { ID = itemTwo.ID };
            checkBoxTwo.CheckedChanged += HideCheckBox;
        }
        void HideCheckBox(object item, EventArgs e)
        {
            if (item.GetType() == typeof(CheckBoxID))
            {
                var checkBoxID = (CheckBoxID)item;
                foreach (ListViewItemID lItem in listViewItems.Where(lItem => lItem.ID == checkBoxID.ID && lItem.Text == "done" && checkBoxID.Checked))
                {
                    checkBoxID.Visible = false;
                }
            }
            else if (item.GetType() == typeof(ListViewItemID))
            {
                var lItem = (ListViewItemID)item;
                foreach (var checkBox in Controls.Where(ctrl => ctrl.GetType() == typeof(CheckBoxID)).Select(ctrl => (CheckBoxID)ctrl).Where(checkBox => checkBox.ID == lItem.ID && checkBox.Checked && lItem.Text == "done"))
                {
                    checkBox.Visible = false;
                }
            }
        }
