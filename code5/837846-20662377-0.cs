      private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string a = textBox4.Text;
            Filtrar(a);
        }
        private void Filtrar(string cad)
        {
            if (cad.Length > 0 && cad.Length < 12)
            {
                var queryFB = from b in obj.beneficiarios
                              where b.beneficiario_ci.IndexOf(cad) != -1
                              select b;
                dataGridView1.DataSource = queryFB;          
            }
            else
            {
                if (cad.Length == 0)
                {
                    dataGridView1.DataSource = obj.beneficiarios;
                }
            }
                
        }
