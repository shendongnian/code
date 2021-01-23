        using System.ComponentModel;
        using System.Web.UI;
    
        /// <summary>
        /// An abstract ImageFilter class.
        /// </summary>
        public abstract class ImageFilter
        {
            /// <summary>
            /// Processes the image with current filter.
            /// </summary>
            /// <param name="image">The image to process.</param>
            /// <returns>Returns a Image after applying current filter.</returns>
            public abstract System.Drawing.Image Process(System.Drawing.Image image);
    
            /// <summary>
            /// Returns a <see cref="System.String"/> that represents this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="System.String"/> that represents this instance.
            /// </returns>
            public override string ToString()
            {
                return "Image Filter";
            }
        }
    
    
    
        public class ResizeFilter : ImageFilter
            {
                private int x = -1;
                private int y = -1;
        
                private int height;
        
                private int width;
        
                private InterpolationMode interpolationMode = InterpolationMode.Bicubic;
        
                private ResizeMode resizeMode = ResizeMode.Fit;
        
                [DefaultValue(-1)]
                [Category("Behavior")]
                public int X
                {
                    get
                    {
                        return this.x;
                    }
        
                    set
                    {
                        if (value < 0)
                        {
                            value = -1;
                        }
        
                        x = value;
                    }
                }
        
                [DefaultValue(-1)]
                [Category("Behavior")]
                public int Y
                {
                    get
                    {
                        return this.y;
                    }
        
                    set
                    {
                        if (value < -1)
                        {
                            value = -1;
                        }
        
                        y = value;
                    }
                }
        
                /// <summary>
                /// Gets or sets a value indicating whether disable transparency.
                /// </summary>
                /// <value>
                /// 	<see langword="true"/> if disable transparency; otherwise, <see langword="false"/>.
                /// </value>
                /// <author>Anwar</author>
                /// <datetime>3/4/2011 5:37 PM</datetime>
                [DefaultValue(false), Category("Behavior")]
                public bool DisableTransparency { get; set; }
        
                /// <summary>
                /// Gets or sets the maximum height of the resulting image.
                /// </summary>
                /// <value>The height of the resulting image.</value>
                [DefaultValue(0)]
                [Category("Behavior")]
                public int Height
                {
                    get
                    {
                        return this.height;
                    }
        
                    set
                    {
                        CheckValue(value);
                        this.height = value;
                    }
                }
        
                /// <summary>
                /// Gets or sets the interpolation mode used for resizing images. The default is HighQualityBicubic.
                /// </summary>
                /// <value>The interpolation mode.</value>
                [DefaultValue(InterpolationMode.HighQualityBicubic)]
                [Category("Behavior")]
                public InterpolationMode InterpolationMode
                {
                    get { return this.interpolationMode; }
        
                    set { this.interpolationMode = value; }
                }
        
                /// <summary>
                /// Gets or sets the resize mode. The default value is Fit.
                /// </summary>
                /// <value>The image resize mode.</value>
                [DefaultValue(ResizeMode.Fit)]
                [Category("Behavior")]
                public ResizeMode ResizeMode
                {
                    get { return this.resizeMode; }
        
                    set { this.resizeMode = value; }
                }
        
                /// <summary>
                /// Gets or sets the maximum width of the resulting image.
                /// </summary>
                /// <value>The width of the image..</value>
                [DefaultValue(0)]
                [Category("Behavior")]
                public int Width
                {
                    get
                    {
                        return this.width;
                    }
        
                    set
                    {
                        CheckValue(value);
                        this.width = value;
                    }
                }
        
                /// <summary>
                /// Processes the image with current filter.
                /// </summary>
                /// <param name="image">The image to process.</param>
                /// <returns>Returns a Image after applying current filter.</returns>
                public override Image Process(Image image)
                {
                    int scaledHeight = (int)(image.Height * (this.Width / (float)image.Width));
                    int scaledWidth = (int)(image.Width * (this.Height / (float)image.Height));
        
                    switch (this.ResizeMode)
                    {
                        case ResizeMode.Fit:
                            return this.FitImage(image, scaledHeight, scaledWidth);
                        case ResizeMode.Crop:
                            return this.CropImage(image, scaledHeight, scaledWidth);
                        default:
                            Debug.Fail("Should not reach this");
                            break;
                    }
        
                    return null;
                }
        
                /// <summary>
                /// Returns a <see cref="System.String"/> that represents this instance.
                /// </summary>
                /// <returns>
                /// A <see cref="System.String"/> that represents this instance.
                /// </returns>
                public override string ToString()
                {
                    return "Resize Filter";
                }
        
                private static void CheckValue(int value)
                {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("value");
                    }
                }
        
                private Image CropImage(Image img, int scaledHeight, int scaledWidth)
                {
                    int resizeWidth;
                    int resizeHeight;
        
                    if (this.Width != 0 && this.Height != 0)
                    {
                        resizeWidth = this.Width;
                        resizeHeight = this.Height;
                    }
                    else if (this.Height == 0)
                    {
                        resizeWidth = this.Width;
                        resizeHeight = scaledHeight;
                    }
                    else if (this.Width == 0)
                    {
                        resizeWidth = scaledWidth;
                        resizeHeight = this.Height;
                    }
                    else
                    {
                        if (this.Width / (float)img.Width > this.Height / (float)img.Height)
                        {
                            resizeWidth = this.Width;
                            resizeHeight = scaledHeight;
                        }
                        else
                        {
                            resizeWidth = scaledWidth;
                            resizeHeight = this.Height;
                        }
                    }
        
                    Bitmap newImage = new Bitmap(this.Width, this.Height);
                    using (Graphics graphics = Graphics.FromImage(newImage))
                    {
                        this.SetupGraphics(graphics);
        
                        if (this.DisableTransparency)
                        {
                            graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, resizeWidth, resizeHeight);
                        }
        
                        int srcX = this.X;
                        int srcY = this.Y;
        
                        if (srcX == -1)
                        {
                            srcX = (this.Width - resizeWidth) / 2;
                        }
        
                        if (srcY == -1)
                        {
                            srcY = (this.Height - resizeHeight) / 2;
                        }
        
                        graphics.DrawImage(img, new Rectangle(0, 0, resizeWidth, resizeHeight), srcX, srcY, resizeWidth, resizeHeight, GraphicsUnit.Pixel);
                    }
        
                    return newImage;
                }
        
                private Image FitImage(Image img, int scaledHeight, int scaledWidth)
                {
                    int resizeWidth;
                    int resizeHeight;
        
                    if (this.Width != 0 && this.Height != 0)
                    {
                        resizeWidth = this.Width;
                        resizeHeight = this.Height;
                    }
                    else if (this.Height == 0)
                    {
                        resizeWidth = this.Width;
                        resizeHeight = scaledHeight;
                    }
                    else if (this.Width == 0)
                    {
                        resizeWidth = scaledWidth;
                        resizeHeight = this.Height;
                    }
                    else
                    {
                        if (this.Width / (float)img.Width < this.Height / (float)img.Height)
                        {
                            resizeWidth = this.Width;
                            resizeHeight = scaledHeight;
                        }
                        else
                        {
                            resizeWidth = scaledWidth;
                            resizeHeight = this.Height;
                        }
                    }
        
                    Bitmap newimage = new Bitmap(resizeWidth, resizeHeight);
                    using (Graphics gra = Graphics.FromImage(newimage))
                    {
                        if (DisableTransparency)
                        {
                            gra.FillRectangle(new SolidBrush(Color.White), 0, 0, resizeWidth, resizeHeight);
                        }
        
                        this.SetupGraphics(gra);
                        gra.DrawImage(img, 0, 0, resizeWidth, resizeHeight);
                    }
        
                    return newimage;
                }
        
                private void SetupGraphics(Graphics graphics)
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighSpeed;
                    graphics.InterpolationMode = this.InterpolationMode;
                }
            }
    
    ////Seprate this enum in your different class ResizeMode.cs
        /// <summary>
            /// Image Resize Modes.
            /// </summary>
            public enum ResizeMode
            {
                /// <summary>
                /// Fit mode maintains the aspect ratio of the original image while ensuring that the dimensions of the result
                /// do not exceed the maximum values for the resize transformation.
                /// </summary>
                Fit,
        
                /// <summary>
                /// Crop resizes the image and removes parts of it to ensure that the dimensions of the result are exactly 
                /// as specified by the transformation.
                /// </summary>
                Crop
            }
    
    ///Your Controller Code
        public class HomeController : Controller
            {
                //
                // GET: /Home/
        
                public ActionResult Index()
                {
                    return View();
                }
                [HttpPost]
                public ActionResult ImportImage()
                {
                    var postedFile = Request.Files["FileUpload1"];
                    if (postedFile != null && postedFile.ContentLength > 0 )
                    {
        
                        MemoryStream ms=new MemoryStream();
        
                        postedFile.InputStream.CopyTo(ms);
        
                        Image image=new Bitmap(ms);
        
                        Guid newImageName=Guid.NewGuid();
                        string newNameToImage = newImageName.ToString() + Path.GetExtension(postedFile.FileName);
                        
                        ResizeFilter resizeFilter=new ResizeFilter {Height = 0, Width = 75};
                        using (Image thumbnailImage = resizeFilter.Process(image))
                        {
                            var imagePath = Path.Combine(Server.MapPath("~/Content/Images"), newNameToImage);
                            thumbnailImage.Save(imagePath);
                        }
                        resizeFilter.Width = 350;
                        resizeFilter.Height = 0;
                        newImageName = Guid.NewGuid();
                        newNameToImage = newImageName.ToString() + Path.GetExtension(postedFile.FileName);
                        using (Image middleImage = resizeFilter.Process(image))
                        {
                            var imagePath = Path.Combine(Server.MapPath("~/Content/Images"), newNameToImage);
                            middleImage.Save(imagePath);
                        }
                    }
                    return RedirectToAction("Index");
                }
            }
        ///View Coding
            @{
                ViewBag.Title = "Index";
            }
            @using (Html.BeginForm("ImportImage", "Home", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {
                <input type="file" name="FileUpload1" id="FileUpload1" />
                <input type="submit" id="submit" />
            }
