    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MySite.WebUI.Models
    {
        public static class Resize
        {
            public static string FindResizeImage(string path, int size)
            {
    
                var _serverpath = HttpContext.Current.Server.MapPath(path);
                if (System.IO.File.Exists(_serverpath))
                {
                    var Extention = Path.GetExtension(path);
                    var _pathresize = path.Substring(0, path.LastIndexOf(".")) + "_" + size.ToString() + Extention;
                    var _serverpathresize = HttpContext.Current.Server.MapPath(_pathresize);
    
                    if (System.IO.File.Exists(_serverpathresize))
                    {
                        return _pathresize.Substring(1, _pathresize.Length - 1);
                    }
                    else
                    {
                        Resize.Resizeing(HttpContext.Current.Server.MapPath(path), HttpContext.Current.Server.MapPath(_pathresize), size);
                        return _pathresize;
                    }
                }
                return null;
            }
            public static void Resizeing(string imageFile, string outputFile, int size)
            {
                using (var srcImage = Image.FromFile(imageFile))
                {
                    using (var newImage = new Bitmap(size, size))
                    using (var graphics = Graphics.FromImage(newImage))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        graphics.DrawImage(srcImage, new Rectangle(0, 0, size, size));
                        newImage.Save(outputFile);
                    }
                }
            }
        }
    }
