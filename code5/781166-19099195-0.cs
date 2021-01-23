    void formcheck()
    {
       foreach(Object item in ListBox1.Items)
       {
         if (item.ToString() == "Form1")
         {
         Form F1 = new Form1{};
         F1.Show()
         }
         if (item.ToString() == "Form2")
         {
         Form F2 = new Form2{};
         F2.Show()
         }
         // And So On...
       }
    }
