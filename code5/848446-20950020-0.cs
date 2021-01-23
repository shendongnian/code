    private void button3_Click(object sender, EventArgs e)
    {
        if (listView1.SelectedIndices.Count == 1)
        {
            ListViewItem item = listView1.SelectedItems[0];            
            int id = Convert.ToInt32(item.SubItems[0].Text);
            var personaje = jugador.nuevosDeudores.First(x => x.identificador == id);
            listView1.Items.Remove(item); // remove from ListView
            jugador.nuevosDeudores.Remove(personaje); // remove from List
            jugador.deudores.Add(personaje); // add to another List
            // Create and add ListViewItem to listView2
        }
    }
