    // your model class
    public class Article
    {
             public WiteableBitmap[] ImagePath { get; set; }
	public string Subject { get; set; }
	public string Words { get; set; }
    }
    //your xaml
    <Image Source="{Binding ImagePath[0]}".../>
    //your cs
    WriteableBitmap writeableBitMap;
    BitmapImage bmp = new BitmapImage(yourimageuri);
    bmp.CreateOptions = BitmapCreateOptions.None;
    bmp.ImageOpened += (sender, event) =>
    {
        
        writeableBitMap = new WriteableBitmap((BitmapImage)sender);
    };
    Article ArticleCollection = new Article();
    ArticleCollection.ImagePath = new WriteableBitmap[yourarraysize];
    ArticleCollection.ImagePath[0] = writeableBitMap;
    articleList.ItemsSource = ArticleCollection;
