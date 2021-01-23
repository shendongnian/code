    partial class Form1
    {
      ItemList Items { get; set; }
      private void Form1_Load(object sender, EventArgs e)
      {
        Items.Fill();
        FillItemsBox();
      }
    }
