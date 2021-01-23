    void listanomesautocomplete(object sender, ServicosLinkedIN.queryCompletedEventArgs e)
            {
    
                if (e.Result[0] != "")
                {
    
                    List<Pessoa> listaPessoas = new List<Pessoa>();
    
                    for (int i = 0; i < e.Result.Count(); i = i + 3)
                    {
                        Pessoa pessoa = new Pessoa();
                        pessoa.Nome = e.Result[i];
                        pessoa.Id = Convert.ToInt32(e.Result[i + 1]);
                        if (e.Result[i + 2] == "")
                            pessoa.Imagem = new BitmapImage(new Uri("Assets/default_perfil.png", UriKind.Relative));
                        else
                        {
                            ServicosLinkedIN.ServicosClient buscaimg = new ServicosLinkedIN.ServicosClient();
                            buscaimg.dlFotoAsync(e.Result[i + 2]);
                            //THIS ACTUALLY WORKS!!!
                            //THE THREAD WAITS FOR IT!
                            buscaimg.dlFotoCompleted += (s, a) =>
                            {
                                pessoa.Imagem = ConvertToBitmapImage(a.Result);
                            };
                        }
                        listaPessoas.Add(pessoa);
                    }
    
                    if (tbA_destinatario.ItemsSource == null)
                    {
    
                        tbA_destinatario.ItemsSource = listaPessoas;
                    }
                    tb_lerdestmsg.Text = "";
                }
                else
                {
                    tbA_destinatario.ItemsSource = null;
                    tb_lerdestmsg.Text = "Não encontrado";
                }
            }
