    public void Save(PromptEntity prompt)
            {
                using (var adapter = new DataAccessAdapter())
                {
                    //start transaction
                    adapter.StartTransaction(IsolationLevel.ReadCommitted, "SavePrompt");
                    try
                    {
                            //saving occurs here.
                            adapter.SaveEntity(prompt);
                            SaveLanguageTranslationCollection(adapter);
                            adapter.Commit();
                    }
                    catch (Exception)
                    {
                        adapter.Rollback();
                        throw;
                    }
                }
            }
