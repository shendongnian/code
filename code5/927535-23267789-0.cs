        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using System.Web;
        using System.Web.Hosting;
        using System.Web.Mvc;
        namespace PlayVideoInMVC.CustomDataResult
        {
            public class VideoDataResult : ActionResult
            {
        /// <summary>
        /// The below method will respond with the Video file
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            
            var strVideoFilePath = HostingEnvironment.MapPath("~/VideoFiles/Test2.mp4");
            
            context.HttpContext.Response.AddHeader("Content-Disposition", "attachment; filename=Test2.mp4");
            var objFile = new FileInfo(strVideoFilePath);
            var stream = objFile.OpenRead();
            var objBytes = new byte[stream.Length];
            stream.Read(objBytes, 0, (int)objFile.Length);
            context.HttpContext.Response.BinaryWrite(objBytes);
                } 
            }
        }
