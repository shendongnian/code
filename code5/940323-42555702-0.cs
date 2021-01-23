        private void tbcaixas_Leave(object sender, EventArgs e)
        {
            Carga();
            int caixas = Convert.ToInt32(tbcaixas.Text);
            List<int> lista = new List<int>();
            for (int i = 1; i <= caixas; i++)
            {
                DataRow linha = dt.NewRow();
                linha["ncaixa"] = "1/" + i;
                linha["loja"] = tbLoja.Text.ToUpper();
                dt.Rows.Add(linha);           
            }
        }
        private void Carga()
        {
            dt = new DataTable();
            dt.Columns.Add("ncaixa", typeof(string));
            dt.Columns.Add("artigo", typeof(string));
            dt.Columns.Add("tam", typeof(string));
            dt.Columns.Add("cor", typeof(string));
            dt.Columns.Add("arte", typeof(string));
            dt.Columns.Add("qtd", typeof(string));
            dt.Columns.Add("und", typeof(string));
            dt.Columns.Add("loja", typeof(string));
            dgvDados.DataSource = dt;
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable dtImpressao = ((DataTable)dgvDados.DataSource);
            var parametro1 = new ReportParameter("data", dtpData.Text);
            var parametro2 = new ReportParameter("cliente", tbCliente.Text);
            var parametro3 = new ReportParameter("notafiscal", tbNotaFiscal.Text);
            var parametro4 = new ReportParameter("pesobruto", tbPesoBruto.Text);
            var parametro5 = new ReportParameter("pesoliquidado", tbPesoLiquidado.Text);
            var parametro6 = new ReportParameter("pesoliquidado", cbEmpresa.SelectedItem.ToString());
            ReportParameter[] paremetros = new ReportParameter[] { parametro1, parametro2, parametro3, parametro4, parametro5 };
            ImpressaoHelper.Imprimir(null, "DataSetRelatorios", "br.com.bonor.Core.relatorios.pcp.Romaneio.rdlc", dtImpressao);
        }
    }
}
