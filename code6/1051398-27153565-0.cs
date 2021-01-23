         /// <summary>Convert and URL Absoluate Path to Relative Path 
         ///(For Example: "~/MyStuff/Images/MsgBoxIcon/MyImg.jpg" ==> "../../MyStuff/Images/MsgBoxIcon/MyImg.jpg"
         ///(Assuming client is currently at the page "~/UI/Pages/Default.aspx", which is two level deep from the root).</summary>
        private static string ConvertAbsoluteToRelativePath(string Input)
        {
            //Init
            string Output = "";
            //Get Current URL (Ex: http://MyWebSite//...)
            string CurrentURL = HttpContext.Current.Request.Url.AbsolutePath;
            //Convert to Relative Path
            Output = VirtualPathUtility.MakeRelative(CurrentURL, Input);
            //Finally
            return Output;
        }
