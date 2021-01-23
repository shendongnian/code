    public static void PushFile(string pathFile, string iddev)
            {         
                string name = Path.GetFileName(pathFile);
                using (var wc = GetClient())
                {
                    using (var multiPartCont = new MultipartFormDataContent())
                    {
                        multiPartCont.Add(addStringContent("device_iden", iddev));
                        multiPartCont.Add(addStringContent("type","file"));
                        multiPartCont.Add(addStreamContent(new FileStream(pathFile,FileMode.Open),name ));
    
                        try
                        {
                            var resp = wc.PostAsync(new Uri(baseUri, "api/pushes"), multiPartCont);
                            Task<string> result = resp.Result.Content.ReadAsStringAsync();
                            //string resultado = result.Result;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }            
            }
