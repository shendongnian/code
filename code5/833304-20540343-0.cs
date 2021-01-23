    using System.IO;
    using System;
    using System.Collections;
    using System.Text.RegularExpressions;
    
    
    class Program
    {
        static void Main()
        {
            
            string Plainttext = "This selection is automatically generated based on videos that were popular <br/>" +
    " in the past few weeks. <br/>" +
    " ------------------------------------------------------------------- \n" +
    " 'Anniversary Prank Backfires!! \n" +
    " http://www.youtube.com/watch?v=R7AXBOT8KzU&feature=em-hot \n" +
    " by RomanAtwood " +
    " 23,268,129 views " +
    " ------------------------------------------------------------------- \n" +
    " We Are The World for Philippines [TYPHOON HAIYAN] \n" +
    " http://www.youtube.com/watch?v=1bI8pGLBagY&feature=em-hot \n" +
    " by Kevin Ayson " +
    " 3,607,584 views <br/>" +
    " ------------------------------------------------------------------- <br/>" +
    " end of text ";
        
            MatchEvaluator evaluator = new MatchEvaluator(MatchFilter);
            
            Console.WriteLine(Regex.Replace(Plainttext, 
            "youtu(?:\\.be|be\\.com)/(?:.*v(?:/|=)|(?:.*/)?)([a-zA-Z0-9-_]+)", evaluator, 
                                          RegexOptions.IgnorePatternWhitespace));  
        }
        
        static string MatchFilter(Match match) {
            var id = match.Groups[1].Value;
            var geturl = match.ToString();
            return  string.Format(@"<table  runat ='server'><tr> <td id = 'tduserPicture' 
                        rowspan='1' style='text-align:left'  runat='server'>
                      <img ID='Imagess2' runat='server' src='{0}' Height='80px' Width='100px'  /alt='image'> 
                  <br/> {1} </td> </tr></table>", "http://img.youtube.com/vi/" + id + "/0.jpg", "www." + geturl);
        }
    }
