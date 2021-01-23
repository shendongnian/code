    private void listaclientes_listbox_DoubleClick(object sender, EventArgs e)
    {
        EditarCliente ed = new EditarCliente(listaclientes_listbox.SelectedIndex, bib);
        ed.Closed += (o,e) => { loadlista_clientes(); }
        ed.Show();
    }
    
 
