    System.Windows.Forms.BindingSource bs;
        public void reloadClients(object source, EventArgs e)
        {
            //Console.WriteLine("Clients will reload.");
            bs = null;
            dgvClientes.DataSource = null;
            bs = new BindingSource();
            dgvClientes.DataSource = bs;
            loadReloadClients = new Thread(new ThreadStart(jobReloadAllClients));
            loadReloadClients.Start();
        }
    
        private void jobReloadAllClients()
        {
            this.Invoke((MethodInvoker)delegate
            {             
                descricaoCliente.Text = "CARREGANDO TODOS OS CLIENTES";      
            });
    
            DataSet Setter = clientes.allClients();        
            this.Invoke((MethodInvoker)delegate
            {
                bs.DataSource = Setter.Tables["Clientes"];
                descricaoCliente.Text = "Todos os Clientes";
    
    
            });
    
        }
