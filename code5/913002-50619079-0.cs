    using System.Linq;
    using System.Threading;
    using OpenQA.Selenium;
    using DotRez.Utilities.WebDriver;
    using System.Drawing;
    using System.Drawing.Imaging;
    // decide take full screenshot and take current window screenshot according to the height 
    public static void TakeSnapshot()
            {
    
                IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
                var fileName = ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier() + DateTime.Now.ToString("HH_mm_ss") + "JS" + ".png";
                var fileLocation = Path.Combine(Configuration.SCREEN_SHOT_LOCATION, fileName);
                Image finalImage;
                // get the full page height and current browser height
                string getCurrentBrowserSizeJS =
                    @"
                
                    window.browserHeight = (window.innerHeight || document.body.clientHeight);
                    window.headerHeight= document.getElementById('site-header').clientHeight;;
                    window.fullPageHeight = document.body.scrollHeight;
                ";
                js.ExecuteScript(getCurrentBrowserSizeJS);
    
    
                // * This is async operation. So we have to wait until it is done.
                string getSizeHeightJS = @"return window.browserHeight;";
                int contentHeight = 0;
                while (contentHeight == 0)
                {
                    contentHeight = Convert.ToInt32(js.ExecuteScript(getSizeHeightJS));
                    if (contentHeight == 0) System.Threading.Thread.Sleep(10);
                }
    
                string getContentHeightJS = @"return window.headerHeight;";
                int siteHeaderHeight = 0;
                while (siteHeaderHeight == 0)
                {
                    siteHeaderHeight = Convert.ToInt32(js.ExecuteScript(getContentHeightJS));
                    if (siteHeaderHeight == 0) System.Threading.Thread.Sleep(10);
                }
    
                string getFullPageHeightJS = @"return window.fullPageHeight";
                int fullPageHeight = 0;
                while (fullPageHeight == 0)
                {
                    fullPageHeight = Convert.ToInt32(js.ExecuteScript(getFullPageHeightJS));
                    if (fullPageHeight == 0) System.Threading.Thread.Sleep(10);
                }
    
                if (contentHeight == fullPageHeight)
                {
                    TakeSnapshotCurrentPage();
    
                }
                else
                {
                    int scollEachHeight = contentHeight - siteHeaderHeight;
                    int shadowAndBorder = 3;
                    int scollCount = 0;
                    int existsIf = (fullPageHeight - siteHeaderHeight) % scollEachHeight;
                    bool cutIf = true;
    
                    if (existsIf == 0)
                    {
                        scollCount = (fullPageHeight - siteHeaderHeight) / scollEachHeight;
                        cutIf = false;
                    }
                    else
                    {
                        scollCount = (fullPageHeight - siteHeaderHeight) / scollEachHeight + 1;
                        cutIf = true;
                    }
    
    
                    // back to top start screenshot
                    string scollToTopJS = "window.scrollTo(0, 0)";
                    js.ExecuteScript(scollToTopJS);
    
                    Byte[] imageBaseContent = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
                    Image imageBase;
                    using (var ms = new MemoryStream(imageBaseContent))
                    {
                        imageBase = Image.FromStream(ms);
                    }
    
                    finalImage = imageBase;
    
                    string scrollBar = @"window.scrollBy(0, window.browserHeight-window.headerHeight);";
                    for (int count = 1; count < scollCount; count++)
                    {
    
                        js.ExecuteScript(scrollBar);
                        Thread.Sleep(500);
                        Byte[] imageContentAdd = ((ITakesScreenshot)Driver).GetScreenshot().AsByteArray;
                        Image imageAdd;
                        using (var msAdd = new MemoryStream(imageContentAdd))
                        {
                            imageAdd = Image.FromStream(msAdd);
                        }
    
                        imageAdd.Save(fileLocation, ImageFormat.Png);
                        Bitmap source = new Bitmap(imageAdd);
                        int a = imageAdd.Width;
                        int b = imageAdd.Height - siteHeaderHeight;
                        PixelFormat c = source.PixelFormat;
    
    
                        // cut the last screen shot if last screesshot override with sencond last one
                        if ((count == (scollCount - 1)) && cutIf)
                        {
    
                            Bitmap imageAddLastCut =
                                source.Clone(new System.Drawing.Rectangle(0, contentHeight - existsIf, imageAdd.Width, existsIf), source.PixelFormat);
    
                            finalImage = combineImages(finalImage, imageAddLastCut);
    
                            source.Dispose();
                            imageAddLastCut.Dispose();
                        }
                        //cut the site header from screenshot
                        else
                        {
                            Bitmap imageAddCutHeader =
                                source.Clone(new System.Drawing.Rectangle(0, (siteHeaderHeight + shadowAndBorder), imageAdd.Width, (imageAdd.Height - siteHeaderHeight - shadowAndBorder)), source.PixelFormat);
                            finalImage = combineImages(finalImage, imageAddCutHeader);
    
                            source.Dispose();
                            imageAddCutHeader.Dispose();
                        }
    
                        imageAdd.Dispose();
    
                    }
    
                    finalImage.Save(fileLocation, ImageFormat.Png);
                    imageBase.Dispose();
                    finalImage.Dispose();
    
                }
            }
    
    //combine two pictures
            public static Bitmap combineImages(Image image1, Image image2)
            {
                Bitmap bitmap = new Bitmap(image1.Width, image1.Height + image2.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.DrawImage(image1, 0, 0);
                    g.DrawImage(image2, 0, image1.Height);
                }
    
                return bitmap;
            }
    
    // take current window screenshot  
          private static void TakeSnapshotCurrentPage()
            {
                try
                {
                    var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                    var urlStr = Driver.Url;
                    var fileName = ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier() + DateTime.Now.ToString("HH_mm_ss") + ".png";
                    var fileLocation = Path.Combine(Configuration.SCREEN_SHOT_LOCATION, fileName);
    
                    if (!Directory.Exists(Configuration.SCREEN_SHOT_LOCATION))
                    {
                        Directory.CreateDirectory(Configuration.SCREEN_SHOT_LOCATION);
                    }
    
                    screenshot.SaveAsFile(fileLocation, ScreenshotImageFormat.Png);
                    Console.WriteLine(urlStr);
                    Console.WriteLine("SCREENSHOT[{0}]SCREENSHOT", Path.Combine("Screenshots", fileName));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
