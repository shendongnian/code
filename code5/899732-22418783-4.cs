    private void button1_Click(object sender, EventArgs e)
    {
       int[] array = new int[] { 1, 3, 4, 5, 6, 7, 8, 99, 22, 44 };
       int[] largest = array
                        .OrderByDescending(item => item)
                        .Take(array.Length).ToArray();
                  
         foreach (var element in largest)
         {
               listBox1.Items.Add(element);
               listView1.Items.Add(new ListViewItem(element.ToString()));
         }
    }
