    using System;
    using WatiN.Core;
    namespace magicbricks
    {
    static class Class1
    {
        private static WatiN.Core.Link _nextPageElement;
        private static string _firstPartOfAddress = "";
        private static string _lastPartOfAddress = "";
        private static int _maxPageCounter = 0;
        [STAThread]
        static void Main(string[] args)
        {
            IE ie = SetUpBrowser();
            EnterFirstWebpage(ie);
            ie.WaitForComplete();
            LookFoAllLinks(ie);
            for (int i = 2; i < _maxPageCounter; i++)
            {
                Console.WriteLine("----------------------------Next Page {0}---------------------------", i);
                Console.WriteLine(AssembleNextPageWebAddress(i));
                EnterNextWebpageUrl(ie,AssembleNextPageWebAddress(i));
                LookFoAllLinks(ie);                               
            }
            Console.ReadKey();
        }
        private static IE SetUpBrowser()
        {
            IE ie = new IE();
            return ie;
        }
        private static void EnterFirstWebpage(IE ie)
        {
            ie.GoTo("http://www.99acres.com/property-in-chennai-ffid?search_type=QS&search_location=HP&lstAcn=HP_R&src=CLUSTER&isvoicesearch=N&keyword_suggest=chennai%20%28all%29%3B&fullSelectedSuggestions=chennai%20%28all%29&strEntityMap=W3sidHlwZSI6ImNpdHkifSx7IjEiOlsiY2hlbm5haSAoYWxsKSIsIkNJVFlfMzIsIFBSRUZFUkVOQ0VfUywgUkVTQ09NX1IiXX1d&texttypedtillsuggestion=chennai&refine_results=Y&Refine_Localities=Refine%20Localities&action=%2Fdo%2Fquicksearch%2Fsearch&suggestion=CITY_32%2C%20PREFERENCE_S%2C%20RESCOM_R");
        }
        private static void EnterNextWebpageUrl(IE ie,string url)
        {
            ie.GoTo(url);
            ie.WaitForComplete();
        }
        private static void LookFoAllLinks(IE ie)
        {
            int currentpageCounter = 0;
            var tmpUrl = string.Empty;
            const string nextPageUrl = "http://www.99acres.com/property-in-chennai-ffid-page-";
            foreach (var currLink in ie.Links)
            {
                if (currLink.Url.Contains("b"))
                {
                    Console.WriteLine(currLink.Url);
                    try
                    {                        
                        if (currLink.Name.Contains("nextbutton"))
                        {                            
                            _nextPageElement = currLink;
                        }
                    }
                    catch (Exception ex)
                    {                                          
                    }
                    try
                    {
                        if (currLink.GetAttributeValue("name").Contains("page"))
                        {
                            _firstPartOfAddress = currLink.Url.Substring(0, nextPageUrl.Length);
                            tmpUrl = currLink.Url.Remove(0,nextPageUrl.Length);
                            _lastPartOfAddress = tmpUrl.Substring(tmpUrl.IndexOf("?"));
                            tmpUrl = tmpUrl.Substring(0,tmpUrl.IndexOf("?"));
                            int.TryParse(tmpUrl, out currentpageCounter);
                            if (currentpageCounter > _maxPageCounter)
                            {
                                _maxPageCounter = currentpageCounter;
                                currentpageCounter = 0;
                            }
                        }
                    }
                    catch (Exception)
                    {                          
                    }
                }
            }
        }
        private static string AssembleNextPageWebAddress(int pageNumber)
        {
            return _firstPartOfAddress + pageNumber + _lastPartOfAddress;
        }
    }
    }
