    var query = from browser in browesers
                            group browser by browser.UserID into UserGroup
                            from countGroup in
                                (from brow in UserGroup
                                 group brow by new
                                     {
                                         Chrome = brow.Browser.Contains("Chrome"),
                                         Firefox = brow.Browser.Contains("Firefox"),
                                         IE = brow.Browser.Contains("IE")
                                     } into test
                                         select new
                                         {
                                             ChromeCount = test.Key.Chrome ? test.Count() : 0,
                                             FirefoxCount = test.Key.Firefox ? test.Count() : 0,
                                             IECount = test.Key.IE ? test.Count() : 0,
                                             OthersCount = (!test.Key.Chrome && !test.Key.Firefox && !test.Key.IE) ? test.Count() : 0
                                         }
                                     )
                            group countGroup by UserGroup.Key;
