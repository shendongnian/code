    async void listanomesautocomplete(object sender, ServicosLinkedIN.queryCompletedEventArgs e)
    {
        if (e.Result[0] != "")
        {
            for (int i = 0; i < e.Result.Count(); i = i + 3)
            {
                Pessoa pessoa = new Pessoa();
                pessoa.Nome = e.Result[i];
                pessoa.Id = Convert.ToInt32(e.Result[i + 1]);
                if (e.Result[i + 2] == "")
                    pessoa.Imagem = new BitmapImage(new Uri("Assets/default_perfil.png", UriKind.Relative));
                else
                {
                    // you probably want to create the service proxy 
                    // outside the for loop
                    using (ServicosLinkedIN.ServicosClient buscaimg = new ServicosLinkedIN.ServicosClient())
                    {
                        FotoCompletedEventHandler handler = null;
                        var tcs = new TaskCompletionSource<Image>();
                        handler = (sHandler, eHandler) =>
                        {
                            buscaimg.dlFotoCompleted -= handler;
                            try
                            {
                                // you can move the code from buscaimg_dlFotoCompleted here,
                                // rather than calling buscaimg_dlFotoCompleted
                                buscaimg_dlFotoCompleted(sHandler, eHandler);
                                tcs.SetResult(eHandler.Result);
                            }
                            catch (Exception ex)
                            {
                                tcs.TrySetException(ex);
                            }
                        };
                        buscaimg.dlFotoCompleted += handler;
                        buscaimg.dlFotoAsync(e.Result[i + 2]);
                        // saving the photo from dlFotoAsync
                        pessoa.Imagem = await tcs.Task;            
                    }
                }
                listaPessoas.Add(pessoa);
            }
            tbA_destinatario.ItemsSource = null;
            tbA_destinatario.ItemsSource = listaPessoas;
            BackgroundWorker listapessoas = new BackgroundWorker();
            listapessoas.DoWork += listapessoas_DoWork;
            listapessoas.RunWorkerAsync();
            tb_lerdestmsg.Text = "";
        }
        else
        {
            tbA_destinatario.ItemsSource = null;
            tb_lerdestmsg.Text = "Não encontrado";
        }
    }
