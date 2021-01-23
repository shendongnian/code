    public async void LoadData()
    {
       //get Json
       string str = await Helper.getJSON(); 
       //Deserialize json
       MainClass apiData = JsonConvert.DeserializeObject<MainClass>(str);
       //the problem loop
       for (int i = 0; i < apiData.Categories.Count;i++ ) 
       {
           //apiData.Categoriesp[i].icon_image is the url of the image
           BitmapImage image = new BitmapImage(new Uri(apiData.Categories[i].icon_image,UriKind.RelativeOrAbsolute));
            
          image.CreateOptions = BitmapCreateOptions.None
         //it never runs
           image.ImageOpened += (s, e) =>
           {
             //code for conversion of image into memory stream
               image.CreateOptions = BitmapCreateOptions.None;
               WriteableBitmap wb = new WriteableBitmap(image);
               MemoryStream ms = new MemoryStream();
               wb.SaveJpeg(ms, image.PixelWidth, image.PixelHeight, 0, 100);
               byte[] imageBytes = ms.ToArray();  
               string base64String = Convert.ToBase64String(imageBytes);
             //setting imageInSql property of the list (but it never runs)
               apiData.Categories[i].imageInSql = base64String;
           }; 
       } 
        //Inserting into database
        using(var db= new SQLiteConnection(App.dbPath)){
                //geting null in imageinSql property.
                db.InsertAll(apiData.Categories,typeof(Category));  
        } 
    } 
