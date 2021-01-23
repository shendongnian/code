    private void button1_Click(object sender, EventArgs e)
        {
            string url = "http://187.72.229.145/esiat/Valida_NFE_Emissao.aspx?InscricaoMunicipal=0032161&NumeroNota=15&CodVrfNfe=TWU7UO47QG";
            string fileName = "pdf.pdf";
            WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(new Uri(url, UriKind.Absolute), fileName);
        }
