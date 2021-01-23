      namespace sadfesrgshtydgf
        {
        public partial class Form1 : Form
        {
            public Form1()
            {
        
                InitializeComponent();
        
            }
        
            private void Completado(WebBrowser b)
            {
                while (b.ReadyState != WebBrowserReadyState.Complete && b.Document.Body == null)
                {
                    webBrowser1.Refresh();
                    Application.DoEvents();
        
                }
            }
            int Pagina = 0;
            private void Form1_Load(object sender, EventArgs e)
            {
                webBrowser1.Navigate("http://voos.infraero.gov.br/voos/index.aspx");
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        
                //Completado(webBrowser1);        
            }
        
        
        
        
            public string diretorio;
        
            public void interfaceUsuario()
            {
        
                diretorio = @"C:\Users\klima\Desktop";
                criarArquivo();
            }
        
            public void criarArquivo()
            {
               MessageBox.Show("Error: Por favor desligue o seu computador ");
                try
                {
                    //var documente = webBrowser1.Document.Body.InnerHtml;
        
                    var documente1 = webBrowser1.Document.GetElementById("grd_voos").OuterHtml;
        
                    //Determino o diretorio onde será salvo o arquivo
                    string nome_arquivo = diretorio + "\\Infraero.txt";
        
                    //verificamos se o arquivo existe, se não existir então criamos o arquivo
                    //if (!File.Exists(nome_arquivo))
                    File.Create(nome_arquivo).Close();
        
                    // crio a variavel responsável por gravar os dados no arquivo txt
                    arquivo = File.AppendText(nome_arquivo);
        
        
        
                    //Escrevo no arquivo txt os dados contidos no textbox
                    arquivo.Write(documente1);
        
        
                    //Posiciono o ponteiro na próxima linha do arquivo.
                    arquivo.Write("\r\n");
        
                    //  MessageBox.Show("Dados salvos com sucesso!!!");
        
        
        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    //Fecho o arquivo
        
                    arquivo.Close();
                }
            }
        
            public void interfaceUsuario1()
            {
        
                diretorio = @"C:\Users\klima\Desktop";
        
                criarArquivo1();
            }
        
        
            public TextWriter arquivo;
        
            public void criarArquivo1()
            {
                try
                {
        
        
        
                    var documentus = webBrowser1.Document.GetElementById("grd_voos").InnerHtml;
        
                    //Determino o diretorio onde será salvo o arquivo
                    string nome_arquivo = diretorio + "\\Infraero1.txt";
        
                    //verificamos se o arquivo existe, se não existir então criamos o arquivo
                    // if (!File.Exists(nome_arquivo))
                    File.Create(nome_arquivo).Close();
        
                    // crio a variavel responsável por gravar os dados no arquivo txt
                    arquivo = File.AppendText(nome_arquivo);
        
        
        
                    //Escrevo no arquivo txt os dados contidos no textbox
                    arquivo.Write(documentus);
        
        
                    //Posiciono o ponteiro na próxima linha do arquivo.
                    arquivo.Write("\r\n");
        
                    //  MessageBox.Show("Dados salvos com sucesso!!!");
        
        
        
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    //Fecho o arquivo
        
                    arquivo.Close();
                }
            }
        
            private void NavegarPagina0()
            {
        
                HtmlElement combo;
                combo = webBrowser1.Document.GetElementById("aero_companias_aeroportos");
                combo.SetAttribute("value", "SBKP");
                HtmlElement botao = webBrowser1.Document.GetElementById("btnPesquisar");
                botao.Document.GetElementById("btnPesquisar").Focus();
                botao.Document.GetElementById("btnPesquisar").InvokeMember("click");
                Pagina++;
        
            }
        
            private void NavegarPagina1()
            {
        
        
        
                HtmlElementCollection doc = webBrowser1.Document.GetElementsByTagName("table")[28].Children[0].Children[0].All;
                HtmlElement a = doc[2].Children[0];
        
                interfaceUsuario();
                a.InvokeMember("click");
                Completado(webBrowser1);
                Pagina++;
        
        
        
        
        
            }
        
            private void NavegarPagina2()
            {
        
                webBrowser1.Refresh();
        
                while(Convert.ToString( webBrowser1.Document.GetElementsByTagName("table")[28].Children[0].Children[0] ) != "1"){
        
        
        
                }
        
                    MessageBox.Show("Nop while");
        
        
                Completado(webBrowser1);
        
        
        
                interfaceUsuario1();
        
                Close();
        
        
            }
        
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
        
        
        
                if (webBrowser1.ReadyState == WebBrowserReadyState.Complete)
                {
                    //webBrowser1.DocumentCompleted -= webBrowser1_DocumentCompleted;
        
                    Completado(webBrowser1);
                    if (Pagina == 0 && webBrowser1.Document.GetElementById("btnPesquisar") != null)
                        NavegarPagina0();
                    else if (Pagina == 1 && webBrowser1.Document.GetElementsByTagName("table")[28] != null)
                        NavegarPagina1();
                    else if (Pagina == 2 && webBrowser1.Document.GetElementsByTagName("table")[28] != null)
                        NavegarPagina2();
        
                }
        
            }
        
            private void webBrowser1_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
        
            }
        
        
        } }
