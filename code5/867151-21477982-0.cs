    private Random rnd = new Random();
    private IEnumerable<string> GetImagesInRandomOrder(){
        return Directory.EnumerateFiles(pfad).OrderBy(x => rnd.Next());
    }
    
    private IEnumerator<string> randomImages = 
              Enumerable.Empty<string>.GetEnumerator();
    
    private string GetNextImage(){
           if(!randomImages.MoveNext()){
              randomImages = GetImagesInRandomOrder().GetEnumerator();
              if(!randomImages.MoveNext()){ 
                  throw new InvalidOperationException("No images"); 
              }   
           }
           return randomImages.Current;
    }
