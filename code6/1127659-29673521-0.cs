    using System.Linq;
    using System.Collections.Generic;
    public class MyForm : Form
    {
        // Event handler for the Forms Load event
        public void MyForm_OnLoad(object sender, EventArgs e)
        {
            // Take 20 items from whatever source you are currently using in the DGV.
            List<MyDataBoundItem> items = objectStorage.Items.Take(20).ToList();
            dataGridView1.DataSource = items;
        }
    }
