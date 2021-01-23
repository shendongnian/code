    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using GhostscriptSharp;
    
    namespace GetPages
    {
        class Program
        {
            static void Main(string[] args)
            {
                GhostscriptWrapper.GeneratePageThumbs(@"C:\Users\User\Downloads\English_Medium_Extra_for_WEB-2.pdf",
                    "Example.png", 1, 3, 130, 130);
            }
        }
    }
