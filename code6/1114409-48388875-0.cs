    ParseQuery<Classes.PermissoesGerenciarMedicos> queryPermissoesMedicos = new ParseQuery<Classes.PermissoesGerenciarMedicos>();
                queryPermissoesMedicos.WhereEqualTo("usuario", ParseUser.CurrentUser as Classes.Usuario).FindAsync().ContinueWith(resultado => {
                    if (resultado.IsCompleted && !resultado.IsFaulted)
                    {
                        if (resultado.Result.Count() == 1)
                        {
                            permissoesGerenciarMedicos = resultado.Result.ElementAt(0) as Classes.PermissoesGerenciarMedicos;
                            carregaPermissoesUsuarios();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao carregar as permissões do usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
                            processandoDadosDelegate processandoDadosD = new processandoDadosDelegate(processandoDados);
                            this.Invoke(processandoDadosD, new object[] { false });
                        }
                    } else
                    {
                        MessageBox.Show("Erro ao carregar as permissões do usuário", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    
                        processandoDadosDelegate processandoDadosD = new processandoDadosDelegate(processandoDados);
                        this.Invoke(processandoDadosD, new object[] { false });
                    }
                });
