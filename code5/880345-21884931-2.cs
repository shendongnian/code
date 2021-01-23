    public void LoadPage(int pageNumber)
            {
                if (pageNumber == 1)
                {
                    this.ArticleCollection.Clear();
                }
    
                IsLoading = true;
                ReadArticleList(pageNumber);
                
            }
    private async void ReadArticleList(int pageNumber)
            {
                try
                {
    
                    List<Article> articleList = new List<Article>();
                    articleList = await CollectionHttpClient.GetArticlesByPageAsync(pageNumber);
    
                    foreach (var item in articleList)
                    {
                        
                        item.BitImage =  await CollectionHttpClient.GetWebImageByImageName(item.ImagePathList[0]);
                       
    
                        this.ArticleCollection.Add(item);
                   
                    }
    
                    IsLoading = false;
                    
    
                }
                catch(Exception ex)
                {
                    if (ex.HResult == -2146233088 && ex.Message.Equals("Response status code does not indicate success: 404 ()."))
                    {
                        MessageBox.Show("The network is not set right. Internet cannot be accessed.");
                    }
                    else
                    {
                        MessageBox.Show("sorry, no data.");
                    }
                    
                    IsLoading = false;
                }
                
            }
